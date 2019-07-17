using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HobbyHub.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId {get;set;}

        public int UserId{get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Hobby must be at least two characters!")]
        public string Name {get;set;}

        [Required]
        [MinLength(5, ErrorMessage="Description must be at least two characters!")]
        [MaxLength(150)]
        public string Description {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Fan> Fan {get;set;}

    }
}