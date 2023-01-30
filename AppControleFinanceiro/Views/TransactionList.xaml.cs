namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly TransactionAdd _transactionAdd;
    private readonly TransactionEdit _transactionEdit;
    private readonly Repositories.ITransactionRepository _transactionRepository;

    public TransactionList(
		TransactionAdd transactionAdd,
        TransactionEdit transactionEdit,
        Repositories.ITransactionRepository transactionRepository)
	{
		InitializeComponent();
		_transactionAdd = transactionAdd;
		_transactionEdit = transactionEdit;
        _transactionRepository = transactionRepository;

        CollectionViewTransactions.ItemsSource = _transactionRepository.GetAll();
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
