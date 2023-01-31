namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;
    private readonly Repositories.ITransactionRepository _transactionRepository;

    public TransactionList(
        Repositories.ITransactionRepository transactionRepository)
	{
		InitializeComponent();
        _transactionRepository = transactionRepository;

        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
    }

	private void OnButtonClicked_GoTo_TransactionAdd(object sender, EventArgs e)
	{
        var transactionAddView = Handler.MauiContext.Services.GetService<TransactionAdd>();
		Navigation.PushModalAsync(transactionAddView);
	}

    void OnButtonClicked_GoTo_TransactionEdit(Object sender, EventArgs e)
    {
        var transactionEditView = Handler.MauiContext.Services.GetService<TransactionEdit>();

        Navigation.PushModalAsync(transactionEditView);
    }
}
