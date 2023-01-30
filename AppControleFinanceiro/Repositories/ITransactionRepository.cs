using System;

namespace ControleFinanceiro.Repositories
{
	public interface ITransactionRepository
	{
        void Add(Models.Transaction transaction);
        void Delete(Models.Transaction transaction);
        List<Models.Transaction> GetAll();
        void Update(Models.Transaction transaction);
    }
}

