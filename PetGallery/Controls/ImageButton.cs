using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PetGallery.Controls
{
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (ImageButton),
                new FrameworkPropertyMetadata(typeof (ImageButton)));
        }

        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public Brush MouseOverColor
        {
            get => (Brush) GetValue(MouseOverColorProperty);
            set => SetValue(MouseOverColorProperty, value);
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(default(ImageSource)));
        
        public static readonly DependencyProperty  MouseOverColorProperty =
            DependencyProperty.Register("MouseOverColor", typeof(Brush), typeof(ImageButton), new PropertyMetadata(default(Brush)));
    }
}