using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_5.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [StringLength(200)]
        public string Location { get; set; }
    }
}
