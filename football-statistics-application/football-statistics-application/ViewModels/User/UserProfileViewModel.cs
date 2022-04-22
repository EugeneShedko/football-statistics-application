using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.User
{
	class UserProfileViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<int> _age;
		private string currentUser;
		private string _userFamilyName;
		private string _userName;
		private string _userAge;
		private string _userDateOfBirthd;
		private string _userCountry;
		private string _userTown;
		private Models.User _currentUserProfile;

		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();


		#endregion
		#region Properties
		public string UserTown
		{
			get { return _userTown; }
			set 
			{ 
				Set(ref _userTown, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (UserTown != null)
				{
					if (!Regex.IsMatch(UserTown, str))
					{
						errors["UserTown"] = "Неверный формат данных";
					}
					else
					{
						errors["UserTown"] = null;
					}
				}
			}
		}
		public string UserCountry
		{
			get { return _userCountry; }
			set 
			{ 
				Set(ref _userCountry, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (UserCountry != null)
				{
					if (!Regex.IsMatch(UserCountry, str))
					{
						errors["UserCountry"] = "Неверный формат данных";
					}
					else
					{
						errors["UserCountry"] = null;
					}
				}
			}
		}
		public string UserDateOfBirthd
		{
			get { return _userDateOfBirthd; }
			set
			{
				Set(ref _userDateOfBirthd, value);
				string str = @"^(0[1-9]|1[0-9]|2[0-9]|3[01])[.](0[1-9]|1[0-2])[.](19[0-9][0-9]|20[0-2][0-9])$";
				if (UserDateOfBirthd != null)
				{
					if (!Regex.IsMatch(UserDateOfBirthd, str))
					{
						errors["UserDateOfBirthd"] = "Неверный формат данных, воозможно dd.mm.yy";
					}
					else
					{
						errors["UserDateOfBirthd"] = null;
					}
				}
			}
		}
		public string UserAge
		{
			get { return _userAge; }
			set { Set(ref _userAge, value); }
		}
		public string UserName
		{
			get { return _userName; }
			set 
			{
				Set(ref _userName, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (UserName != null)
				{
					if (!Regex.IsMatch(UserName, str))
					{
						errors["UserName"] = "Неверный формат данных";
					}
					else
					{
						errors["UserName"] = null;
					}
				}
			}
		}
		public string UserFamilyName
		{
			get { return _userFamilyName; }
			set
			{
				Set(ref _userFamilyName, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (UserFamilyName != null)
				{
					if (!Regex.IsMatch(UserFamilyName, str))
					{
						errors["UserFamilyName"] = "Неверный формат данных";
					}
					else
					{
						errors["UserFamilyName"] = null;
					}
				}
			}
		}
		public Models.User CurrentUserProfile
		{
			get { return _currentUserProfile; }
			set { Set(ref _currentUserProfile, value); }
		}
		#endregion
		public ObservableCollection<int> Age
		{
			get { return _age; }
			set { Set(ref _age, value); }
		}
		#region Constructors
		public UserProfileViewModel(NavigationManager smallNaviagationInfoMnager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNaviagationInfoMnager;
		}
		public UserProfileViewModel() 
		{
			errors = new Dictionary<string, string>();
			SaveChanges = new DelegateCommand(SaveChangesCommand, CanSaveChangesCommand);
		}
		#endregion
		#region Commands
		public ICommand SaveChanges { get; set; }
		private bool CanSaveChangesCommand(object parameters)
		{
			return true;
		}
		private void SaveChangesCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				CurrentUserProfile.FamilyName = UserFamilyName;
				CurrentUserProfile.Name = UserName;
				CurrentUserProfile.Age = UserAge;
				CurrentUserProfile.DateOfBirthd = UserDateOfBirthd;
				CurrentUserProfile.Country = UserCountry;
				CurrentUserProfile.Town = UserTown;
				db.Users.Update(CurrentUserProfile);
				db.Save();
				MessageBox.Show("Данные успешно сохранены!");
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing()
		{ }
		public void ActionsBeforeInsert(object parameters = null)
		{
			CreateAgeCollection();
			currentUser = (string)parameters;
			using (UnitOfWork db = new UnitOfWork())
			{
				CurrentUserProfile = db.Users.GetAll().Where(t => t.LoginId == currentUser).First();
			}
			UserFamilyName = CurrentUserProfile.FamilyName;
			UserName = CurrentUserProfile.Name;
			UserAge = CurrentUserProfile.Age;
			UserDateOfBirthd = CurrentUserProfile.DateOfBirthd;
			UserCountry = CurrentUserProfile.Country;
			UserTown = CurrentUserProfile.Town;
		}
		private void CreateAgeCollection()
		{
			Age = new ObservableCollection<int>();
			for (int i = 10; i <= 60; i++)
				Age.Add(i);
		}
	}
	#endregion
}