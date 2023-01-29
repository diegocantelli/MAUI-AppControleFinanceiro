namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnButtonClicked_GoTo_TransactionAdd(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new TransactionAdd());
	}

    void OnButtonClicked_GoTo_TransactionEdit(Object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new TransactionEdit());
    }
}
