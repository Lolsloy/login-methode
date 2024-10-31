using Loginsfunktion.Data;
using Loginsfunktion.Models;
using Microsoft.EntityFrameworkCore; 
using var context = new anzeige();
do
{
    string emails;
    Login user = new Login();
    Console.WriteLine("Geben Sie bitte Ihre E-Mail ein:");
    emails = Console.ReadLine();
    user.email = emails;  

    bool isvalid = user.emailfalidierung(emails);


    if (!context.Users.Any(u => u.email == user.email)&&isvalid) 
    {
        Console.WriteLine("Geben Sie bitte Ihr Passwort ein:");
        string eingegebenepasswort = Console.ReadLine();
        user.password = user.HashedPassword(eingegebenepasswort); 
        context.Add(user);
        context.SaveChanges();
        Console.WriteLine("Benutzer wurde hinzugefügt.");
    }
    else if(!isvalid)
    {
        Console.WriteLine("Geben sie bitte eine ordentliche email ");
    }
    else 
    {
        Console.WriteLine("Geben Sie bitte Ihr Passwort ein:");
        string eingegebenepasswort = Console.ReadLine(); 

        var existingUser = context.Users.First(u => u.email == user.email);

        bool isPasswordCorrect = existingUser.Passwortbestätigung(existingUser.password, eingegebenepasswort);

        if (isPasswordCorrect) 
        {
            Console.WriteLine("Passwort korrekt.");
        }
        else 
        {
            Console.WriteLine("Falsches Passwort.");
        }
    }
} while (true);



























//string Password = "Ibrahim";
//string PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(Password, 13);
//string svaedpassword = PasswordHash;
//Console.WriteLine(PasswordHash);
//bool richtig=false;
//if (PasswordHash == svaedpassword)
//{
//    richtig = true;
//    Console.WriteLine("super");
//}