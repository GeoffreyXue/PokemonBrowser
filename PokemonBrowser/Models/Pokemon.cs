using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PokemonBrowser.Models
{
    public class Pokemon : IComparable<Pokemon>
    {
        [Key]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public string Url { get; set; }

        public Pokemon(string name) { Name = name; }

        public int CompareTo(Pokemon other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
