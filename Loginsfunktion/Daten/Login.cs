using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Loginsfunktion.Models
{
    internal class Login
    {
        [Key]
        public string email { get; set; } = null!;


        [Required]
        public string password { get; set; }= null!;
 

        public string HashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }
        public bool Passwortbestätigung(string hashedPassword, string enteredPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(enteredPassword, hashedPassword);
        }

        public bool emailfalidierung(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
