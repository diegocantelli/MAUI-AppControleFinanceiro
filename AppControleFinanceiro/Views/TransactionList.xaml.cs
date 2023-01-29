namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnButtonClicked_GoTo_TransactionAdd(object sender, EventArgs e)
	{
		AppControleFinanceiro.App.Current.MainPage = new TransactionAdd();
	}

    void OnButtonClicked_GoTo_TransactionEdit(Object sender, EventArgs e)
    {
		AppControleFinanceiro.App.Current.MainPage = new TransactionEdit();
    }
}
