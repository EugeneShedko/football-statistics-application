using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Navigation
{
	public interface INavigationManager
	{
		void Insert(string navigationKey, object parameters = null);
	}
}
