using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;
using WpfApp1.View;

namespace WpfApp1.ViewModels
{
	class RegisterWindowViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private string _familyName;
		private string _name;
		private string _login;
		private string _password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManager;
		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();
		#endregion
		#region Properties
		public string FamilyName
		{
			get { return _familyName; }
			set 
			{
				Set(ref _familyName, value);
				string str = @"^[А-Яа-я]+$";
				if (FamilyName != null)
				{
					if (!Regex.IsMatch(FamilyName, str))
					{
						errors["FamilyName"] = "Неверный формат данных";
					}
					else
					{
						errors["FamilyName"] = null;
					}
				}
			}
		}
		public string Name
		{
			get { return _name; }
			set 
			{
				Set(ref _name, value);
				string str = @"^[А-Яа-я]+$";
				if (Name != null)
				{
					if (!Regex.IsMatch(Name, str))
					{
						errors["Name"] = "Неверный формат данных";
					}
					else
					{
						errors["Name"] = null;
					}
				}
			}
		}
		public string Login
		{
			get { return _login; }
			set 
			{
				Set(ref _login, value);
				string str = @"^[a-z0-9]{1,10}$";
				if (Name != null)
				{
					using (UnitOfWork db = new UnitOfWork())
					{
						bool isLogin = db.Users.GetAll().Any(t=>t.LoginId == Login);
						if (isLogin == true)
						{
							errors["Login"] = "Пользователь с таки логином уже существует";
						}
						else
						{
							if (!Regex.IsMatch(Login, str))
							{
								errors["Login"] = "Неверный формат данных";
							}
							else
							{
								errors["Login"] = null;
							}
						}
					}
				}

			}
		}
		public string Password
		{
			get { return _password; }
			set 
			{ 
				Set(ref _password, value);
				string str = @"^[a-z0-9]{1,10}$";
				if (Name != null)
				{
					if (!Regex.IsMatch(Password, str))
					{
						errors["Password"] = "Неверный формат данных";
					}
					else
					{
						errors["Password"] = null;
					}
				}

			}
		}
		#endregion
		#region Constructors
		public RegisterWindowViewModel(NavigationManager smallNavigationManager,NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationLoginManager = smallNavigationManager;
		}
		public RegisterWindowViewModel()
		{
			errors = new Dictionary<string, string>();
			errors["FamilyName"] = null;
			errors["Name"] = null;
			errors["Login"] = null;
			errors["Password"] = null;
			Register = new DelegateCommand(RegisterCommand, CanRegisterCommand);
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(object parameters = null){}
		public void ActionsBeforeClosing(){}
		#endregion
		#region Commands
		public ICommand Register { get; set; }
		private bool CanRegisterCommand(object parameter)
		{
			if ((errors["FamilyName"] == null && FamilyName != null) &&
				(errors["Name"] == null && Name != null) &&
				(errors["Login"] == null && Login != null) &&
				(errors["Password"] == null && Password != null))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void RegisterCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				try
				{
					Models.User newUser = new Models.User(Login, GetHach(Password),FamilyName, Name);
					db.Users.Create(newUser);
					db.Save();
					ShowLoginWindowCommand(null);
				}
				catch { }
			}
		}
		private void ShowLoginWindowCommand(object parameter)
		{
			_smallNavigationLoginManager.AddUserControl<LoginWindowViewModel, LoginWindow>(new LoginWindowViewModel(_smallNavigationLoginManager, _navigationManager), NavigationKeys.LoginWindow);
			_smallNavigationLoginManager.Insert(NavigationKeys.LoginWindow);
		}
		private string GetHach(string input)
		{
			var md5 = MD5.Create();
			var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
			return Convert.ToBase64String(hash);
		}
		#endregion
	}
}
