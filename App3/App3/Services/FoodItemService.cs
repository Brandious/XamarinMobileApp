using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database.Query;
using App3.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace App3.Services
{
    public class FoodItemService
    {
        FirebaseClient client;

        public FoodItemService()
        {
            client = new FirebaseClient("https://xamarinmobile-435a1-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems").OnceAsync<FoodItem>()).Select(c => new FoodItem
            {
                CategoryID = c.Object.CategoryID,
                Description = c.Object.Description,
                HomeSelected = c.Object.HomeSelected,
                ImageUrl = c.Object.ImageUrl,
                Name=c.Object.Name,
                Price=c.Object.Price,
                ProductID = c.Object.ProductID,
                Rating=c.Object.Rating,
                RatingDetail = c.Object.RatingDetail,

            }).ToList();

            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();

            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);

            }

            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);

            foreach(var item in items)
            {
                latestFoodItems.Add(item);

            }
        }
    }
}
