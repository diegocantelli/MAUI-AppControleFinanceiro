namespace AppControleFinanceiro;
using ControleFinanceiro.Views;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new TransactionList());
	}
}

