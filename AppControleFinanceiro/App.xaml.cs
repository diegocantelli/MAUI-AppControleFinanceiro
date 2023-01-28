namespace AppControleFinanceiro;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new ControleFinanceiro.Views.TransactionList();
	}
}

