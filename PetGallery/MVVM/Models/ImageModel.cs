using System;

namespace PetGallery.MVVM.Models
{
    public class ImageModel
    {
        public Uri Url { get; set; }
        public string Id { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}