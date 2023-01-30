namespace AppControleFinanceiro;
using ControleFinanceiro.Views;

public partial class App : Application
{
    private readonly TransactionList _transactionList;

    public App(TransactionList transactionList)
	{
		InitializeComponent();

		_transactionList = transactionList;

        MainPage = new NavigationPage(_transactionList);
	}
}

