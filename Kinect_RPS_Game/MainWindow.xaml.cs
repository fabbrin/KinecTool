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
using System.Runtime.InteropServices;
using System.Diagnostics;
using CCT.NUI.Core;
using CCT.NUI.Core.OpenNI;
using CCT.NUI.Core.Video;
using CCT.NUI.Visual;
using CCT.NUI.HandTracking;
using CCT.NUI.KinectSDK;
using CCT.NUI.Core.Clustering;
using System.Windows.Media.Media3D;
using System.Threading;
using System.Windows.Threading;
using OpenNI;

namespace CCT.NUI.WPFSamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Kinect.KinectSensor sensor;

        // initialize the int 
        public int resultfinger = -1; // int that cointains number of fingers
        public int palm = -1; // cointains number of palm
        public int rand = -1; // initialize the random int

        private HandInterfaceElement element = null;

        private IDataSourceFactory factory;
        private IHandDataSource handDataSource;
        private IClusterDataSource clusterDataSource;

        public MainWindow()
        {
            InitializeComponent();
            this.Start();
            this.ToggleLayers();
            txtInfo.Text = "RPS Kinect v1.0 Developed by Niccolò Fabbri   E-mail: niccolo.fabbri@stud.unifi.it   Teacher: Prof. Andrew David Bagdanov";
            textBox1.FontSize = 36;
        }

        // this method allows to choose the image

        enum GestureStatus
        {
            None = 0,
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        GestureStatus gs = GestureStatus.None;
        private void GestureReact()
        {
            switch (gs)
            {
                case GestureStatus.None:
                    imgGesture.Source = new BitmapImage(new Uri("./Images/None.png", UriKind.Relative));
                    break;
                case GestureStatus.Rock:
                    imgGesture.Source = new BitmapImage(new Uri("./Images/SASSO.png", UriKind.Relative));
                    break;
                case GestureStatus.Paper:
                    imgGesture.Source = new BitmapImage(new Uri("./Images/CARTA.png", UriKind.Relative));
                    break;
                case GestureStatus.Scissors:
                    imgGesture.Source = new BitmapImage(new Uri("./Images/FORBICE.png", UriKind.Relative));
                    break;
            }
        }

        // this method allows to choose the image for USER Icon
        enum GestureStatus1
        {
            doubt = 0,
            smile = 1,
            nosmile = 2
        }
        GestureStatus1 gs1 = GestureStatus1.doubt;
        private void GestureReact1()
        {
            switch (gs1)
            {
                case GestureStatus1.doubt:
                    man.Source = new BitmapImage(new Uri("./Images/YELLOW.jpg", UriKind.Relative));
                    break;
                case GestureStatus1.smile:
                    man.Source = new BitmapImage(new Uri("./Images/GREEN.jpg", UriKind.Relative));
                    break;
                case GestureStatus1.nosmile:
                    man.Source = new BitmapImage(new Uri("./Images/RED.jpg", UriKind.Relative));
                    break;
            }
        }

        // this method allows to choose the image for CPU Icon
        enum GestureStatus2
        {
            doubt = 0,
            smile = 1,
            nosmile = 2
        }
        GestureStatus2 gs2 = GestureStatus2.doubt;
        private void GestureReact2()
        {
            switch (gs2)
            {
                case GestureStatus2.doubt:
                    cpu.Source = new BitmapImage(new Uri("./Images/YELLOW.jpg", UriKind.Relative));
                    break;
                case GestureStatus2.smile:
                    cpu.Source = new BitmapImage(new Uri("./Images/GREEN.jpg", UriKind.Relative));
                    break;
                case GestureStatus2.nosmile:
                    cpu.Source = new BitmapImage(new Uri("./Images/RED.jpg", UriKind.Relative));
                    break;
            }
        }

        // Little logic to RPS Game,  when no hand found, it reset the GetRandom Number
        public void RPS_Game()
        {
            if (resultfinger == 5 || resultfinger == 4)
            {
                GetWinner_Paper(rand);
            }
            if (resultfinger == 3 || resultfinger == 2)
            {
                GetWinner_Scissors(rand);
            }
            if (resultfinger == 1 || resultfinger == 0)
            {
                GetWinner_Rock(rand);
                resultfinger = -1;
            }
            else if ((palm == 1 && resultfinger == 0) || resultfinger == -1) // palm == 1 || || resultfinger == -1 || count == 0)
            {
                textBox1.Text = "No Hand Found";
                imgGesture.Source = new BitmapImage(new Uri("./Images/banhand1.png", UriKind.Relative));
                cpu.Source = new BitmapImage(new Uri("./Images/CPU.png", UriKind.Relative));
                man.Source = new BitmapImage(new Uri("./Images/MAN.png", UriKind.Relative));
                rand = GetRandomNumber(0, 3);
            }
        }

        public void HandInterfaceWindow(IHandDataSource handDataSource, IImageDataSource imageDataSource)
        {
            this.element = new HandInterfaceElement();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Start()
        {
            // initialize sensor Microsoft Kinect SDK
            sensor = Microsoft.Kinect.KinectSensor.KinectSensors.FirstOrDefault();
            sensor.Start();
            sensor.ElevationAngle = 13;

            // initialize some element 

            this.Cursor = Cursors.Wait;
            this.factory = new SDKDataSourceFactory();

            this.clusterDataSource = this.factory.CreateClusterDataSource(new Core.Clustering.ClusterDataSourceSettings { MaximumDepthThreshold = 900 });
            this.handDataSource = new HandDataSource(this.factory.CreateShapeDataSource(this.clusterDataSource, new Core.Shape.ShapeDataSourceSettings()));

            var depthImageSource = this.factory.CreateDepthImageDataSource();
            depthImageSource.NewDataAvailable += new NewDataHandler<ImageSource>(MainWindow_NewDataAvailable);
            handDataSource.NewDataAvailable += new NewDataHandler<HandCollection>(handDataSource_NewDataAvailable);
            HandInterfaceWindow(this.handDataSource, depthImageSource);
            //new HandInterfaceWindow(this.handDataSource, this.rgbImageDataSource).Show();
            depthImageSource.Start();
            handDataSource.Start();
            this.Cursor = Cursors.Arrow;

        }

        void handDataSource_NewDataAvailable(HandCollection data)
        {
            // for each frame, count number of fingers (resultfinger), if no hand found is 0
            for (int index = 0; index < data.Count; index++)
            {
                var hand = data.Hands[index];
                resultfinger = hand.FingerCount;
                if (hand.HasPalmPoint == true)
                {
                    palm = 1;
                }
                else
                {
                    palm = 0;
                }
                this.element.Update(data);
            }
        }

        // random function to choose int between 0 and 2. 0 rock, 1 scissors, 2 paper
        public int GetRandomNumber(int min, int max)
        {
            Random r = new Random();
            int rInt = r.Next(min, max);
            return rInt;
        }

        //function that calculates the win of paper gesture
        public void GetWinner_Paper(int rand)
        {
            GestureReact();
            GestureReact1();
            GestureReact2();
            if (rand == 2)
            {
                gs = GestureStatus.Paper;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.doubt;
                gs2 = GestureStatus2.doubt;
            }
            else if (rand == 0)
            {
                gs = GestureStatus.Rock;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.smile;
                gs2 = GestureStatus2.nosmile;
            }
            else if (rand == 1)
            {
                gs = GestureStatus.Scissors;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.nosmile;
                gs2 = GestureStatus2.smile;
            }
        }

        //function that calculates the win of scissors gesture
        public void GetWinner_Scissors(int rand)
        {
            GestureReact();
            GestureReact1();
            GestureReact2();
            if (rand == 1)
            {
                gs = GestureStatus.Scissors;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.doubt;
                gs2 = GestureStatus2.doubt;
            }
            else if (rand == 0)
            {
                gs = GestureStatus.Rock;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.nosmile;
                gs2 = GestureStatus2.smile;
            }
            else if (rand == 2)
            {
                gs = GestureStatus.Paper;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.smile;
                gs2 = GestureStatus2.nosmile;
            }
        }

        //function that calculates the win of rock gesture
        public void GetWinner_Rock(int rand)
        {
            GestureReact();
            GestureReact1();
            GestureReact2();
            if (rand == 0)
            {
                gs = GestureStatus.Rock;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.doubt;
                gs2 = GestureStatus2.doubt;
            }
            else if (rand == 1)
            {
                gs = GestureStatus.Scissors;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.smile;
                gs2 = GestureStatus2.nosmile;
            }
            else if (rand == 2)
            {
                gs = GestureStatus.Paper;
                textBox1.Text = "Play Again? Remove your hand!";
                gs1 = GestureStatus1.nosmile;
                gs2 = GestureStatus2.smile;
            }
        }

        void MainWindow_NewDataAvailable(ImageSource data)
        {
            RPS_Game();
            this.videoControl.Dispatcher.Invoke(new Action(() =>
            {
                this.videoControl.ShowImageSource(data);
            }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Action(() =>
            {
                this.handDataSource.Stop();
                this.factory.Dispose();
            }).BeginInvoke(null, null);
        }

        // add the layers (read report) around at the hand found
        private void ToggleLayers()
        {
            var layers = new List<IWpfLayer>();
            layers.Add(new WpfHandLayer(this.handDataSource));
            this.videoControl.Layers = layers;
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtInfo_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        //button to show instruction
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void focusTarger_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
