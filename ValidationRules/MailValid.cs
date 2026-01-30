using Pract_12.Data;
using Pract_12.Service;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pract_12.ValidationRules
{
    class MailValid : ValidationRule
    {
        public UsersService service { get; set; } = new();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = "";
            ObservableCollection<User> st = service.Users;
            var input = (value ?? "").ToString().Trim();
            if(!input.Contains("@"))
                return new ValidationResult(false, "Должен быть символ @");
            for (int i = 0; i < input.Count(); i++)
            {
                if (!Char.IsUpper(input[i]))
                {
                    text += Char.ToLower(input[i]);
                }
                else
                {
                    text += input[i];
                }
            }
            foreach (var a in st)
            {
                string text2 = "";
                for (int i = 0; i < a.Email.Count(); i++)
                {
                    if (!Char.IsUpper(a.Email[i]))
                    {
                        text2 += Char.ToLower(a.Email[i]);
                    }
                    else
                    {
                        text2 += a.Email[i];
                    }
                }
                if (text == text2)
                {
                    return new ValidationResult(false, "Такая почта уже есть");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
