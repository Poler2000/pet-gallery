using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PetGallery.Core;
using PetGallery.DB;
using PetGallery.MVVM.Models;

namespace PetGallery.MVVM.ViewModels
{
    
    public class ImageDetailsViewModel : ObservableObject
    {
        private Visibility _viewVisibility = Visibility.Visible;
        public ImageSource CurrentImage { get; set; }
        public ImageModel CurrentImageData { get; set; }
        public RelayCommand ReturnCommand { get; set; }
        public RelayCommand PrevCommand { get; set; }
        public RelayCommand NextCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public Visibility ViewVisibility
        {
            get => _viewVisibility;
            set
            {
                _viewVisibility = value;
                OnPropertyChanged();
            }
        }

        public ImageDetailsViewModel(ICardCollection collection, ImageModel im)
        {
            CurrentImageData = im;
            if (ImageFileManager.FileExists(im.Path))
            {
                CurrentImage = new BitmapImage(new Uri(im.Path));
            }
            else
            {
                CurrentImage = new BitmapImage(im.Url);
            }

            ReturnCommand = new RelayCommand(o =>
            {
                ViewVisibility = Visibility.Hidden;
            });

            PrevCommand = new RelayCommand(_ => collection.PreviousImage());
            NextCommand = new RelayCommand(_ => collection.NextImage());
            AddCommand = new RelayCommand(_ => { collection.AddButtonAction(); });
            RemoveCommand = new RelayCommand(_ => { collection.RemoveButtonAction(); });

            SaveCommand = new RelayCommand(_ =>
            {
                var collectionManager = new CollectionManager(SqliteDataAccess.Instance);
                collectionManager.UpdateImageData(CurrentImageData);
            });
        }
    }
}