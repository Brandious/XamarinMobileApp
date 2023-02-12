using App3.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database.Query;

namespace App3.Helpers
{
    public class AddCategoryData
    {
        FirebaseClient client;

        public List<Category> Categories { get; set;  }
        public AddCategoryData()
        {
            client = new FirebaseClient("https://xamarinmobile-435a1-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>()
           {
               new Category() {CategoryID = 1, CategoryName="Burger", CategoryPoster="MainBurger", ImageUrl="Burger.png"},
            new Category() {CategoryID = 2, CategoryName="Pizza", CategoryPoster="MainBurger", ImageUrl="Burger.png"},
 new Category() {CategoryID = 3, CategoryName="Desserts", CategoryPoster="MainBurger", ImageUrl="Burger.png"},
 new Category() {CategoryID = 4, CategoryName="Vegan", CategoryPoster="MainBurger", ImageUrl="Burger.png"},
 new Category() {CategoryID = 5, CategoryName="Cakes", CategoryPoster="MainBurger", ImageUrl="Burger.png"},

           };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(
                        new Category()
                        {
                            CategoryID = category.CategoryID,
                            CategoryName = category.CategoryName,
                            CategoryPoster = category.CategoryPoster,
                            ImageUrl = category.ImageUrl
                        });
                }
                 
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
