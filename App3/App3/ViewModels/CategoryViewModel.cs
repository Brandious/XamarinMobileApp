using App3.Model;
using App3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App3.ViewModels
{
    public class CategoryViewModel: BaseViewModel
    {
		private Category _selectedCategory;

		public Category SelectedCategory
		{
			get { return _selectedCategory; }
			set { _selectedCategory = value; OnPropertyChanged(); }
		}

		public ObservableCollection<FoodItem> FoodItemsByCategory { get; set; }

		private int _totalFoodItems;

		public int TotalFoodItems
		{
			get { return _totalFoodItems; }
			set { _totalFoodItems = value; OnPropertyChanged(); }
		}

		public CategoryViewModel(Category category)
		{
			SelectedCategory= category;
			FoodItemsByCategory = new ObservableCollection<FoodItem>();
			GetFoodItems(category.CategoryID);

		}

        private async void GetFoodItems(int categoryID)
        {
			var data = await new FoodItemService().GetFoodItemsByCategoryAsync(categoryID);
			FoodItemsByCategory.Clear();
			foreach(var item in data)
			{
				FoodItemsByCategory.Add(item);
			}

			TotalFoodItems = FoodItemsByCategory.Count;
        }
    }
}
