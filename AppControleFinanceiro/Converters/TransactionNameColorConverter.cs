using System;
using System.Globalization;

namespace ControleFinanceiro.Converters
{
    public class TransactionNameColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return Color.FromArgb("#FFFFFF");
            }

            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000));

            return Color.FromArgb(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

