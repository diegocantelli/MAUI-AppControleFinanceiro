using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionEdit(Repositories.ITransactionRepository transactionRepository)
	{
		InitializeComponent();

        _transactionRepository = transactionRepository;
    }

	public void SetTransactionToEdit(Models.Transaction transaction)
	{
		_transaction = transaction;

		if (_transaction.Type == TransactionType.Income)
			RadioIncome.IsChecked = true;
		else
            RadioExpense.IsChecked = true;

		EntryName.Text = _transaction.Name;
		DatePickerDate.Date = _transaction.Date.Date;
        EntryValue.Text = _transaction.Value.ToString();

    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var transactionUpd = new Transaction
        {
            Id = _transaction.Id,
            Date = DatePickerDate.Date,
            Name = EntryName.Text,
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expense,
            Value = double.Parse(EntryValue.Text)
        };

        _transactionRepository.Update(transactionUpd);

        Navigation.PopModalAsync();
        WeakReferenceMessenger.Default.Send<string>(string.Empty);

    }
}
