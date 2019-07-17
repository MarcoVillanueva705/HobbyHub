using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbyHub.Models
{
    public class LoginUser
    {
        [EmailAddress]
        [Required]
        public string Email {get; set;}

        [Required]
        public string UserName {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
    }
}