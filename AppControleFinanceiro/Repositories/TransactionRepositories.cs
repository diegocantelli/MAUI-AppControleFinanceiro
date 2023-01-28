using System;
using System.Transactions;
using LiteDB;

namespace ControleFinanceiro.Repositories
{
	public class TransactionRepositories : ITransactionRepository
	{
        private readonly LiteDatabase _database;
        private readonly string collectionName = "transactions";

        public TransactionRepositories(LiteDatabase database)
		{
            _database = database;
        }

        public void Add(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Insert(transaction);
        }

        public void Delete(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAll()
        {
            return _database
                .GetCollection<Transaction>(collectionName)
                .Query()
                .ToList();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}

