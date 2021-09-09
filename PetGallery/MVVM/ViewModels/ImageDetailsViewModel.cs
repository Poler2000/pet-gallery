using System;
using System.Windows;
using PetGallery.Core;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    public class ImageDetailsViewModel : ObservableObject
    {
        private Visibility _viewVisibility = Visibility.Visible;
        public ImageModel CurrentImage { get; set; }
        public RelayCommand ReturnCommand { get; set; }

        public Visibility ViewVisibility
        {
            get => _viewVisibility;
            set
            {
                _viewVisibility = value;
                OnPropertyChanged();
            }
        }

        public ImageDetailsViewModel(ImageModel im)
        {
            CurrentImage = im;
            ReturnCommand = new RelayCommand(o =>
            {
                ViewVisibility = Visibility.Hidden;
            });
        }
    }
}