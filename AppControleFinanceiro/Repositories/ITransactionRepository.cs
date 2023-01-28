using System;
using System.Transactions;

namespace ControleFinanceiro.Repositories
{
	public interface ITransactionRepository
	{
        void Add(Transaction transaction);
        void Delete(Transaction transaction);
        List<Transaction> GetAll();
        void Update(Transaction transaction);
    }
}

