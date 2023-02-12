using App3.Model;
using App3.Services;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
		private string _username;

		public string Username
		{
			get { return _username; }
			set { _username = value; OnPropertyChanged(); }
		}

		private int _userCartItemsCount;

		public Command LogoutCommand { get; set; }
		public Command ViewCartCommand { get; set; }
		public int UserCartItemsCount
		{
			get { return _userCartItemsCount; }
			set { _userCartItemsCount = value; OnPropertyChanged(); }
		}

		public ProductViewModel()
		{

			var uname = Preferences.Get("Username", String.Empty);
			if (String.IsNullOrEmpty(uname))
				Username = "Guest";
			else
				Username = uname;

			UserCartItemsCount = new CartItemService().GetUserCartCount();
			Categories = new ObservableCollection<Category>();
			LatestItems = new ObservableCollection<FoodItem>();

			ViewCartCommand = new Command(async () => await ViewCartAsync());
			LogoutCommand = new Command(async () => await LogoutAsync());
			GetCategories();
			GetLatestItems();
		}

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());


        }

        private async Task ViewCartAsync()
        {
			await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());

        }

        public ObservableCollection<Category> Categories { get; set; }
		public ObservableCollection<FoodItem> LatestItems { get; set;  }

	
		private async void GetCategories()
		{
			var data = await new CategoriesDataService().GetCategoriesAsync();
			Categories.Clear();

			foreach(var item in data)
			{
				Categories.Add(item);
			}

		}

		private async void GetLatestItems()
		{
			var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();

            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
	}
}
