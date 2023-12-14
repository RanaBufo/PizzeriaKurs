using Pizzeria.Models;
using System.Text.RegularExpressions;

namespace Pizzeria.Services
{
    public class ValidService
    {
        public ValidService()
        {
           
        }

        public bool IsValidName(string name)
        {
            string pattern = "^[a-zA-Z]*$";

            if (name != null && Regex.IsMatch(name, pattern))
            {
                return true;
            } return false;
        }

        public bool IsValidSurname(string surname)
        {
            string pattern = "^[a-zA-Z]*$";

            if (surname != null && Regex.IsMatch(surname, pattern))
            {
                return true;
            }
            return false;
        }

        public bool IsValidPhone(string phone)
        {
            string pattern = "^[0-9]*$";

            if (phone != null && Regex.IsMatch(phone, pattern) && phone.Length == 11)
            {
                return true;
            }
            return false;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = "^[\\w\\.-]+@[a-zA-Z\\d\\.-]+\\.[a-zA-Z]{2,}$\r\n";

            if (email != null && email.IndexOf('@') != 0)
            {
                return true;
            }
            return false;
        }
        public bool IsValidPost(string post)
        {
            string pattern = "^[a-zA-Z]*$";

            if (post != null && Regex.IsMatch(post, pattern))
            {
                return true;
            }
            return false;
        }
        public bool IsValidPassword(string password)
        {
            string pattern = "^[0-9a-zA-Z]*$";

            if (password != null && Regex.IsMatch(password, pattern) && password.Length <= 11 && password.Length >= 8)
            {
                return true;
            }
            return false;
        }
        public bool IsValidDuplicatePassword(string password, string duplicatePassword)
        {

            if (password == duplicatePassword)
            {
                return true;
            }
            return false;
        }

    }
}
