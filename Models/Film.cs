using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StackExchange.Redis;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string? Title { get; set; }

        public string? Genre { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
