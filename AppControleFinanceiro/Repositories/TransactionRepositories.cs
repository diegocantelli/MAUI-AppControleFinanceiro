using System;
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

        public void Add(Models.Transaction transaction)
        {
            var col = _database.GetCollection<Models.Transaction>(collectionName);
            col.Insert(transaction);
        }

        public void Delete(Models.Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Models.Transaction> GetAll()
        {
            return _database
                .GetCollection<Models.Transaction>(collectionName)
                .Query()
                .ToList();
        }

        public void Update(Models.Transaction transaction)
        {
            var col = _database.GetCollection<Models.Transaction>(collectionName);
            col.Update(transaction);
        }
    }
}

