﻿using System;
using System.Globalization;

namespace ControleFinanceiro.Converters
{
	public class TransactionValueConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var transaction = (Models.Transaction)value;

            if (transaction == null)
            {
                return string.Empty;
            }

            if(transaction.Type == Models.TransactionType.Income)
                return transaction.Value.ToString("C");
            else
                return $"- {transaction.Value.ToString("C")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

