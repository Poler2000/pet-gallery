namespace PetGallery.Core
{
    public interface ICardCollection
    {
        public void PreviousImage();
        public void NextImage();
        public void AddButtonAction();
        public void RemoveButtonAction();
    }
}