namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;

    public TransactionList(
		TransactionAdd transactionAdd,
        TransactionEdit transactionEdit)
	{
		InitializeComponent();
		_transactionAdd = transactionAdd;
		_transactionEdit = transactionEdit;
    }

	private void OnButtonClicked_GoTo_TransactionAdd(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(_transactionAdd);
	}

    void OnButtonClicked_GoTo_TransactionEdit(Object sender, EventArgs e)
    {
		Navigation.PushModalAsync(_transactionEdit);
    }
}
