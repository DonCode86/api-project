using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StackExchange.Redis;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using StringLengthAttribute = System.ComponentModel.DataAnnotations.StringLengthAttribute;

namespace api_project.Models
{
    public class Film
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to insert the title")]
        [StringLength(40)]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true), DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [DateLessThanOrEqualToToday]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Genre")]
        public string GenreName { get; set; }
    }
    public class DateLessThanOrEqualToToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Date value should not be a future date";
        }

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            if (dateValue.Date > DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

    }
}
