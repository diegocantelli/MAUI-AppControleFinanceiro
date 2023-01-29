namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnButtonClicked_GoTo_TransactionAdd(object sender, EventArgs e)
	{
		Navigation.PushAsync(new TransactionAdd());
	}

    void OnButtonClicked_GoTo_TransactionEdit(Object sender, EventArgs e)
    {
		Navigation.PushAsync(new TransactionEdit());
    }
}
