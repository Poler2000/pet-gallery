using System;
using System.Windows;
using System.Windows.Input;

namespace PetGallery.MVVM.Views
{
    public partial class InputDialog : Window
    {
        public InputDialog()
        {
            InitializeComponent();
        }
        
        public string Response {
            get => ResponseBox.Text;
            set => ResponseBox.Text = value;
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void InputDialog_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}