using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace CCT.NUI.WPFSamples
{
    // The VideoSurface class allows you to configure the video source to suit your own needs

    public class VideoSurface
    {
        public VideoSurface(string mediaSource)
        {
            this.ModelVisual3D = new ModelVisual3D();

            var geometryModel = new GeometryModel3D();
            this.ModelVisual3D.Content = geometryModel;

            this.geometry = new MeshGeometry3D();
            geometryModel.Geometry = geometry;

            var positions = new Point3DCollection();
            positions.Add(new Point3D(0, 0, 0));            
            positions.Add(new Point3D(413, 0, 0));
            positions.Add(new Point3D(413, 417, 0));
            positions.Add(new Point3D(0, 417, 0));
            this.geometry.Positions = positions;

            var textureCoordinates = new PointCollection();
            textureCoordinates.Add(new System.Windows.Point(0, 1));
            textureCoordinates.Add(new System.Windows.Point(1, 1));
            textureCoordinates.Add(new System.Windows.Point(1, 0));
            textureCoordinates.Add(new System.Windows.Point(0, 0));
            this.geometry.TextureCoordinates = textureCoordinates;

            var triangleIndices = new Int32Collection();
            triangleIndices.Add(0);
            triangleIndices.Add(1);
            triangleIndices.Add(2);
            triangleIndices.Add(2);
            triangleIndices.Add(3);
            triangleIndices.Add(0);
            this.geometry.TriangleIndices = triangleIndices;

            var material = new EmissiveMaterial();
            var brush = new VisualBrush();
            this.border = new Border();
            this.border.BorderBrush = Brushes.White;
            this.border.BorderThickness = new Thickness(10);
            this.border.Opacity = 0;

            this.mediaElement = new MediaElement();
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Source = new Uri(mediaSource);

            this.border.Child = mediaElement;
            brush.Visual = border;
            material.Brush = brush;
            geometryModel.Material = material;

            this.mediaElement.MediaEnded += new RoutedEventHandler(mediaElement_MediaEnded);
        }

        public ModelVisual3D ModelVisual3D
        {
            get;
            private set;
        }

        private MeshGeometry3D geometry;
        private MediaElement mediaElement;
        private Border border;

        void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.OnRequestRemove();
        }

        protected void OnRequestRemove()
        {
            if (this.RequestRemove != null)
            {
                this.RequestRemove(this, EventArgs.Empty);
            }
        }
        public event EventHandler RequestRemove;

    }
}
