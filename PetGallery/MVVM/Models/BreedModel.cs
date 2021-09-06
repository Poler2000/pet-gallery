using Newtonsoft.Json;

namespace PetGallery.MVVM.Models
{
    public class BreedModel
    {
        public string Id { get; set; } 
        
        public string Name { get; set; }
        
        [JsonProperty("life_span")]
        public string LifeSpan { get; set; } 
        
        public string Origin { get; set; } 
        
        public ImageModel Image { get; set; }
    }
}