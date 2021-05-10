using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Navigation
{
	public interface INavigationActions
	{
		void ActionsBeforeInsert();
		void ActionsBeforeClosing();
	}
}
