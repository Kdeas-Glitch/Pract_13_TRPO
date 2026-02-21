using Pract_12.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Pract_12.ValidationRules
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;

            bool isVisible = false;

            if (!string.IsNullOrEmpty(path))
            {
                isVisible = true;
                //if (File.Exists("pack://application:,,,/Images/" + path))
                if(path== "default-avatar.png")
                {
                    return "pack://application:,,,/Images/" + path;
                }


            }

            return "pack://application:,,,/Images/key.jpg";
            //return "/Images/default-avatar.png";



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
