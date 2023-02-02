using System;
using System.Globalization;

namespace ControleFinanceiro.Converters
{
    public class TransationNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var nome = (string)value;

            return nome.ToUpper()[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

