using System.Text;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionAdd(Repositories.ITransactionRepository transactionRepository)
	{
		InitializeComponent();
        _transactionRepository = transactionRepository;
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    void OnButtonClicked_Save(System.Object sender, System.EventArgs e)
    {
        if (!IsValidData())
            return;

        SaveTransactionInDatabase();
    }

    private void SaveTransactionInDatabase()
    {
        Models.Transaction transaction = new Models.Transaction()
        {

            Type = RadioIncome.IsChecked ? Models.TransactionType.Income : Models.TransactionType.Expense,
            Name = EntryName.Text,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValor.Text)
        };

        _transactionRepository.Add(transaction);
    }

    private bool IsValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }
        if (string.IsNullOrEmpty(EntryValor.Text) || string.IsNullOrWhiteSpace(EntryValor.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }
        double result;
        if (!string.IsNullOrEmpty(EntryValor.Text) && !double.TryParse(EntryValor.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' é inválido!");
            valid = false;
        }


        if (valid == false)
        {
            LabelError.IsVisible = true;
            LabelError.Text = sb.ToString();
        }
        return valid;
    }


}
