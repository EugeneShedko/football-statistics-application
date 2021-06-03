using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.UnitOfWorkAndRepository
{
	interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T Get(int id);
		void Create(T item);
		void Update(T item);
		bool Delete(int id);
	}
}
