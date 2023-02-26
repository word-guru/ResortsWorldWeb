using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ResortsWorldWeb.Model.Entity
{
    public class Resport
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [AllowNull]
        public float Rating { get; set; }
        public int CountriesId { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Rating} - {Description} - {CountriesId}";
        }
    }
}
