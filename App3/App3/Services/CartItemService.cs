using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Firebase.Database.Query;

namespace App3.Services
{
    public class CartItemService
    {
        FirebaseClient client;

       
        public CartItemService()
        {
            client = new FirebaseClient("https://xamarinmobile-435a1-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public int GetUserCartCount()
        {
            return 0;
        }

        public void RemoveItemsFromCount()
        {

        }
    }
}
