using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pract_12.ValidationRules
{
    class PasswordValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            bool sim = false;
            bool dig = false;
            bool LetSm = false;
            bool LetBg = false;
            char[] simb = { '!', '@', '#', '%', '^', '&', '*', '(',')', '№', '?' };
            var input = (value ?? "").ToString().Trim();
            if (input.Length <  8)
            {
                return new ValidationResult(false, "Должно быть 8 символов");
            }
            for (int i = 0; i < input.Length; i++)
            {
                char a = input[i];
                if (Char.IsNumber(a))
                {
                    dig = true;
                }
                else {
                    if (simb.Contains(a))
                    {
                        sim = true;
                    }
                    else
                    {

                        if (Char.IsLetter(a) && (!simb.Contains(a)))
                        {
                            if (Char.IsUpper(a))
                            {
                                LetBg = true;
                            }
                            if (Char.IsLower(a))
                            {
                                LetSm = true;
                            }
                        }
                    }
                }
            }
            if (!(sim && dig && LetSm && LetBg))
            {
                return new ValidationResult(false, "Нет обязательных символов(символы, цифры, буквы в верхнем и нижнем регистре)");
            }
            return ValidationResult.ValidResult;
        }
    }
}
