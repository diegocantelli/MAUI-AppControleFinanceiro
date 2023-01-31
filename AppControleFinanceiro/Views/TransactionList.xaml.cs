using CommunityToolkit.Mvvm.Messaging;

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

        Reload();
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            Reload();
        });
    }

    private void Reload()
    {
        var items = _transactionRepository.GetAll();
        CollectionViewTransactions.ItemsSource = items;

        double income = items.Where(x => x.Type == Models.TransactionType.Income)
            .Sum(x => x.Value);

        double expense = items.Where(x => x.Type == Models.TransactionType.Expense)
            .Sum(x => x.Value);

        double balance = income - expense;

        LabelIncome.Text = income.ToString("C");
        LabelExpense.Text = expense.ToString("C");
        LabelBalance.Text = balance.ToString("C");

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
