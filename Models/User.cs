using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace HobbyHub.Models
{
     public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [MinLength(2)]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }
        
        [Required] 
        [MinLength(2)]
        [Display(Name="Last Name: ")]       
        public string LastName { get; set; }

        [Required] 
        [MinLength(3, ErrorMessage="Must be a min of 3 characters!")]
        [MaxLength(15, ErrorMessage="Must be a max of 15 characters!")]
        [Display(Name="UserName: ")]       
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Fan> Fan {get;set;}
        
        }
}