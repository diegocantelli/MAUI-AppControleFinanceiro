using ControleFinanceiro.Models;

namespace ControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
    private Transaction _transaction;

    public TransactionEdit()
	{
		InitializeComponent();
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
}
