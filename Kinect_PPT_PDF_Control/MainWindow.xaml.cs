using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;

namespace Kinect_PPT_PDF_Control
{
    public partial class MainWindow : Window
    {
        KinectSensor sensor;

        public int switchmode = 0; // int to choose ppt or pdf mode
        public double minVal = 1; // when skeleton (Joint Spine, Z component) goes under 1 (1mt), disable the tracking -> to reduce error when i close the presentation program
        public double maxVal = 3.5; // when skeleton (Joint Spine, Z component) goes over 3,5 (3,5mt) disable the tracking

        byte[] colorBytes;
        Skeleton[] skeletons;

        // this bool active/deactive gesture function
        bool isForwardGestureActive = false;
        bool isBackGestureActive = false;
        bool isStartGestureActive = false;
        bool isExitGestureActive = false;

        SolidColorBrush activeBrush = new SolidColorBrush(Colors.Green); // when gesture are recognized
        SolidColorBrush inactiveBrush = new SolidColorBrush(Colors.Red); // when hands or head are tracked

        public MainWindow()
        {
            InitializeComponent();
            txtInfo.Text = "Kinect PPT/PDF Control   E-mail: niccolo.fabbri@stud.unifi.it   Teacher: Prof. Andrew David Bagdanov";
            textBox1.FontSize = 22;
            txtInfo.FontSize = 13.5;

            //Runtime initialization is handled when the window is opened. When the window
            //is closed, the runtime MUST be unitialized.
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            sensor = KinectSensor.KinectSensors.FirstOrDefault();

            // Control if the kinect device is connected
            if (sensor == null)
            {
                MessageBox.Show("This application requires a Kinect sensor.");
                this.Close();
            }

            sensor.Start();
            sensor.ElevationAngle = 13; //start at 13 degree

            textBoxElevationAngle.Text = sensor.ElevationAngle.ToString();

            // Start sensor to receive color, depth and skeleton stream
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs>(sensor_ColorFrameReady);

            sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30); // suggest doesn't increase resolution. Perfect balance between speed and precision

            sensor.SkeletonStream.Enable();
            sensor.SkeletonFrameReady += new EventHandler<SkeletonFrameReadyEventArgs>(sensor_SkeletonFrameReady);

            Application.Current.Exit += new ExitEventHandler(Current_Exit);

        }

        void Current_Exit(object sender, ExitEventArgs e)
        {
            if (sensor != null)
            {
                sensor.Stop();
                sensor.Dispose();
                sensor = null;
            }
        }

        void sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var image = e.OpenColorImageFrame())
            {
                if (image == null)
                    return;

                if (colorBytes == null ||
                    colorBytes.Length != image.PixelDataLength)
                {
                    colorBytes = new byte[image.PixelDataLength];
                }

                image.CopyPixelDataTo(colorBytes);

                //You could use PixelFormats.Bgr32 below to ignore the alpha,
                //or if you need to set the alpha you would loop through the bytes 
                //as in this loop below
                int length = colorBytes.Length;
                for (int i = 0; i < length; i += 4)
                {
                    colorBytes[i + 3] = 255;
                }

                BitmapSource source = BitmapSource.Create(image.Width,
                    image.Height,
                    96,
                    96,
                    PixelFormats.Bgra32,
                    null,
                    colorBytes,
                    image.Width * image.BytesPerPixel);
                videoImage.Source = source;
            }
        }

        void sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (var skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame == null)
                    return;

                if (skeletons == null ||
                    skeletons.Length != skeletonFrame.SkeletonArrayLength)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }

                // decide to identify only one skeleton at a time, choose the closest
                skeletonFrame.CopySkeletonDataTo(skeletons);
                Skeleton closestSkeleton = skeletons.Where(s => s.TrackingState == SkeletonTrackingState.Tracked)
                                                .OrderBy(s => s.Position.Z * Math.Abs(s.Position.X))
                                                .FirstOrDefault();

                if (closestSkeleton == null)
                    return;

                if (closestSkeleton.Joints[JointType.Spine].Position.Z < minVal)
                {
                    textBox1.Text = ("Skeleton Tracking disabled (too near)");
                    closestSkeleton.TrackingState = SkeletonTrackingState.NotTracked;
                }
                else if (closestSkeleton.Joints[JointType.Spine].Position.Z > maxVal)
                {
                    textBox1.Text = ("Skeleton Tracking disabled (too far)");
                    closestSkeleton.TrackingState = SkeletonTrackingState.NotTracked;
                }

                // The points that kinect track

                var head = closestSkeleton.Joints[JointType.Head];
                var rightHand = closestSkeleton.Joints[JointType.HandRight];
                var leftHand = closestSkeleton.Joints[JointType.HandLeft];

                var centerShoulder = closestSkeleton.Joints[JointType.ShoulderCenter];
                var leftShoulder = closestSkeleton.Joints[JointType.ShoulderLeft];
                var rightShoulder = closestSkeleton.Joints[JointType.ShoulderRight];

                var centerHip = closestSkeleton.Joints[JointType.HipCenter];

                if (head.TrackingState == JointTrackingState.NotTracked ||
                    rightHand.TrackingState == JointTrackingState.NotTracked ||
                    leftHand.TrackingState == JointTrackingState.NotTracked ||
                    centerHip.TrackingState == JointTrackingState.NotTracked ||
                    centerShoulder.TrackingState == JointTrackingState.NotTracked ||
                    leftShoulder.TrackingState == JointTrackingState.NotTracked ||
                    rightShoulder.TrackingState == JointTrackingState.NotTracked)
                {
                    //Don't have a good read on the joints so we cannot process gestures
                    return;
                }

                //SetEllipsePosition is the method to color canvas element

                SetEllipsePosition(ellipseHead, head, false);
                SetEllipsePosition(ellipseLeftHand, leftHand, isBackGestureActive);
                SetEllipsePosition(ellipseRightHand, rightHand, isForwardGestureActive);

                if (isStartGestureActive)
                {
                    SetEllipsePosition(ellipseLeftHand, leftHand, isStartGestureActive);
                    SetEllipsePosition(ellipseRightHand, rightHand, isStartGestureActive);
                }
                else if (isExitGestureActive)
                {
                    SetEllipsePosition(ellipseLeftHand, leftHand, isExitGestureActive);
                    SetEllipsePosition(ellipseRightHand, rightHand, isExitGestureActive);
                }

                ProcessForwardBackGesture(head, rightHand, leftHand, centerShoulder, rightShoulder, leftShoulder, centerHip);
            }
        }

        //This method is used to position the ellipses on the canvas
        //according to correct movements of the tracked joints.
        private void SetEllipsePosition(Ellipse ellipse, Joint joint, bool isHighlighted)
        {
            if (isHighlighted)
            {
                ellipse.Width = 40;
                ellipse.Height = 40;
                ellipse.Fill = activeBrush;
            }
            else
            {
                ellipse.Width = 40;
                ellipse.Height = 40;
                ellipse.Fill = inactiveBrush;
            }

            CoordinateMapper mapper = sensor.CoordinateMapper;

            var point = mapper.MapSkeletonPointToColorPoint(joint.Position, sensor.ColorStream.Format);

            Canvas.SetLeft(ellipse, (point.X / (1.697612732095491)) - ellipse.ActualWidth / 2);
            Canvas.SetTop(ellipse, (point.Y / (1.395348837209302)) - ellipse.ActualHeight / 2);
        }

        // This is the most important function. With some constraints, define the gestures.

        private void ProcessForwardBackGesture(Joint head, Joint rightHand, Joint leftHand, Joint centerShoulder, Joint rightShoulder, Joint leftShoulder, Joint centerHip)
        {
            if ((rightHand.Position.Y < centerHip.Position.Y) && (leftHand.Position.Y < centerHip.Position.Y) && (Math.Abs(rightShoulder.Position.Y - leftShoulder.Position.Y) < 0.2))
            {
                if ((rightHand.Position.X > head.Position.X + 0.45))
                {
                    if (!isForwardGestureActive)
                    {
                        isForwardGestureActive = true;
                        System.Windows.Forms.SendKeys.SendWait("{Right}");
                        textBox1.Text = "\r\nNext Slide";
                    }
                }
                else
                {
                    isForwardGestureActive = false;
                }

                if ((leftHand.Position.X < head.Position.X - 0.45))
                {
                    if (!isBackGestureActive)
                    {
                        isBackGestureActive = true;
                        System.Windows.Forms.SendKeys.SendWait("{Left}");
                        textBox1.Text = "\r\nPrevious Slide";
                    }
                }
                else
                {
                    isBackGestureActive = false;
                }
            }

            else
            {

                if ((rightHand.Position.Y + 0.2 > head.Position.Y) && (leftHand.Position.Y + 0.2 > head.Position.Y))
                {
                    if (!isStartGestureActive)
                    {
                        isStartGestureActive = true;
                        if (switchmode == 0)
                        {
                            System.Windows.Forms.SendKeys.SendWait("{F5}");
                        }
                        else if (switchmode == 1)
                        {
                            System.Windows.Forms.SendKeys.SendWait("^(l)");
                        }
                        textBox1.Text = "\r\nStart Presentation";
                    }
                }
                else
                {
                    isStartGestureActive = false;
                }

                if ((Math.Abs(rightHand.Position.X - leftHand.Position.X) < 0.1) && (Math.Abs(rightHand.Position.Y - leftHand.Position.Y) < 0.1) && (Math.Abs(rightShoulder.Position.Y - leftShoulder.Position.Y) < 0.1))
                {
                    if (!isExitGestureActive)
                    {
                        isExitGestureActive = true;
                        System.Windows.Forms.SendKeys.SendWait("{ESC}");
                        textBox1.Text = "\r\nExit Presentation";
                    }
                }
                else
                {
                    isExitGestureActive = false;
                }
            }

        }

        private void ShowWindow()
        {
            this.Topmost = true;
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        private void HideWindow()
        {
            this.Topmost = false;
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        // button to choose ppt mode
        private void btn_Click_PPT(object sender, RoutedEventArgs e)
        {
            btn.IsEnabled = true;
            if (btn.IsEnabled)
            {
                switchmode = 0;
            }
        }

        //button to choose pdf mode
        private void btn_Click_PDF(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = true;
            if (btn1.IsEnabled)
            {
                switchmode = 1;
            }

        }

        //button to show gesture
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        // plus button increase elevation angle
        private void BtnCameraUpClick(object sender, RoutedEventArgs e)
        {
            try
            {
                sensor.ElevationAngle = sensor.ElevationAngle + 5;
                textBoxElevationAngle.Text = sensor.ElevationAngle.ToString();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                //Elevation angle must be between Elevation Minimum/Maximum"
                MessageBox.Show(outOfRangeException.Message);
            }
        }

        // minus button decrease elevation angle
        private void BtnCameraDownClick(object sender, RoutedEventArgs e)
        {
            try
            {
                sensor.ElevationAngle = sensor.ElevationAngle - 5;
                textBoxElevationAngle.Text = sensor.ElevationAngle.ToString();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                //Elevation angle must be between Elevation Minimum/Maximum"
                MessageBox.Show(outOfRangeException.Message);
            }
        }

        private void txtInfo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_txtElevationAngle(object sender, TextChangedEventArgs e)
        {

        }
    }
}
