using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        async void ButtonCategories_Clicked(object sender, EventArgs e) { var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }
        async void ButtonProducts_Clicked(object sender, EventArgs e) { var afd = new AddFoodItem();
            await afd.AddFoodItemAsync();
        }

        async void ButtonCartItems_Clicked(object sender, EventArgs e)
        {
            var ci = new CreateCartTable();
            if (ci.CreateTable())
                DisplayAlert("Success", "Cart Table Created", "OK");
            else
                DisplayAlert("Error", "Error while creating table", "OK");
            
        }
    }
}