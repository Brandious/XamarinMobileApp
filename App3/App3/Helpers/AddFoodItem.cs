using App3.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Data;
using Xamarin.Forms;

namespace App3.Helpers
{
    public class AddFoodItem
    {
        public List<FoodItem> FoodItems { get; set; }

        FirebaseClient client;
        public AddFoodItem()
        {
            client = new FirebaseClient("https://xamarinmobile-435a1-default-rtdb.europe-west1.firebasedatabase.app/");

            FoodItems = new List<FoodItem>()
            {
                new FoodItem{ProductID=8,CategoryID=3, ImageUrl="MainDessert", Name="Cakes", Description="Some cool cakes", Rating="4.8", RatingDetail="(156 raitings)", HomeSelected="EmptyHeart", Price=45}
            };
        }

        public async Task AddFoodItemAsync()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating =  item.Rating,
                        RatingDetail = item.RatingDetail,
                    });

                }
            }catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
