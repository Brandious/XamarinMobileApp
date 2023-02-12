using App3.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;

namespace App3.Services
{
    public class CategoriesDataService
    {
        FirebaseClient client;
        public CategoriesDataService()
        {
            client = new FirebaseClient("https://xamarinmobile-435a1-default-rtdb.europe-west1.firebasedatabase.app/");

        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories").OnceAsync<Category>()).Select(c => new Category
            {
                CategoryID = c.Object.CategoryID,
                CategoryName = c.Object.CategoryName,
                CategoryPoster = c.Object.CategoryPoster,
                ImageUrl = c.Object.ImageUrl
            }).ToList();

            return categories;
        }
    }
}
