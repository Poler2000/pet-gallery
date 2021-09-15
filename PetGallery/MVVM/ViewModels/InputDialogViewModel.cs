using PetGallery.Core;

namespace PetGallery.MVVM.ViewModels
{
    public class InputDialogViewModel : ObservableObject
    {
        private string _collectionTitle;

        public string CollectionTitle
        {
            get => _collectionTitle;
            set
            {
                _collectionTitle = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AcceptCommand;

        public InputDialogViewModel()
        {
            AcceptCommand = new RelayCommand(o =>
            {
            });
        }
    }
}