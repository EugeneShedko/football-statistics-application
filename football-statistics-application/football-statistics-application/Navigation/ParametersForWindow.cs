using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Navigation
{
	class ParametersForWindow
	{
		#region Fields
		public object[] Parameters { get; set;}
		#endregion
		#region Constructors
		public ParametersForWindow(int size)
		{
			Parameters = new object[size];
		}
		public ParametersForWindow() { }
		#endregion
	}
}
