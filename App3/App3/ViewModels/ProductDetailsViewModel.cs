using App3.Model;
using App3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.ViewModels
{ 
    public class ProductDetailsViewModel:BaseViewModel
    {
		private FoodItem _selectedFoodItem;

		public FoodItem SelectedFoodItem
		{
			get { return _selectedFoodItem; }
			set { _selectedFoodItem = value; OnPropertyChanged(); }
		}


		private int _totalQuantity;

		public int TotalQuantity
		{
			get { return _totalQuantity; }
			set {
                _totalQuantity = value;
                if (this._totalQuantity < 0) _totalQuantity = 0;
				else if (this.TotalQuantity > 10) this.TotalQuantity -= 1;
				OnPropertyChanged(); }
		}

		public Command IncrementOrderCommand { get; set; }	
		public Command DecrementOrderCommand { get; set;}
		public Command AddToCartCommand { get; set; }
		public Command ViewCartCommand { get; set; }
		public Command HomeCommand { get; set; }

		public ProductDetailsViewModel(FoodItem foodItem)
		{
			SelectedFoodItem = foodItem;
			TotalQuantity = 0;

			IncrementOrderCommand = new Command(() => IncrementOrder());
			DecrementOrderCommand = new Command(() => DecrementOrder());
			AddToCartCommand = new Command(() => AddToCart());

			ViewCartCommand = new Command(async () => await ViewCartAsync());
			HomeCommand = new Command(async () => await GotoHomeAsync());
		}

        private async Task GotoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductView());

        }

        private async Task ViewCartAsync()
        {
			await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private void AddToCart()
        {
			var cn = DependencyService.Get<ISQLite>().GetConnection();
			try
			{
				CartItem ci = new CartItem()
				{
					ProductId = SelectedFoodItem.ProductID,
					ProductName = SelectedFoodItem.Name,
					Price = SelectedFoodItem.Price,
					Quantity = TotalQuantity

				};
				var item = cn.Table<CartItem>().ToList().FirstOrDefault(c => c.ProductId == SelectedFoodItem.ProductID);

				if (item == null)
					cn.Insert(ci);
				else
				{
					item.Quantity += TotalQuantity;
					cn.Update(item);
				}

				cn.Commit();
				cn.Close();
				Application.Current.MainPage.DisplayAlert("Cart", "Selected Item added to cart","OK");



			}catch(Exception ex)
			{
                Application.Current.MainPage.DisplayAlert("Cart",ex.Message, "OK");

            }
			finally
			{
				cn.Close();
			}
        }

        private void DecrementOrder()
        {
			TotalQuantity--;
        }

        private void IncrementOrder()
        {
			TotalQuantity++;
        }
    }
}
