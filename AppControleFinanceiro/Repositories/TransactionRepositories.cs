using System;
using System.Transactions;

namespace ControleFinanceiro.Repositories
{
	public class TransactionRepositories : ITransactionRepository
	{
		public TransactionRepositories()
		{
		}

        public void Add(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}

