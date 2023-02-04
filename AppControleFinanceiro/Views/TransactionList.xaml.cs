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

    void TapGestureRecognizer_Tapped_Goto_TransactionEdit(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        var transaction = (Models.Transaction)gesture.CommandParameter;

        var transactionEditView = Handler.MauiContext.Services.GetService<TransactionEdit>();
        transactionEditView.SetTransactionToEdit(transaction);

        Navigation.PushModalAsync(transactionEditView);
    }

    private async Task AnimationBorder(Border border, bool IsDeleteAnimation)
    {
        if (IsDeleteAnimation)
        {
            await border.RotateYTo(180, 1000);
        }
        else
        {

        }
    }
}
