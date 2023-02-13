using App3.Model;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;


        public CategoryView(Category category)
        {
            InitializeComponent();

            cvm = new CategoryViewModel(category);
            this.BindingContext = cvm;
        }

        async void ImageButton_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void CollectionView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct =  e.CurrentSelection as FoodItem;
            if (selectedProduct != null)
            {
                return;
            }

            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));

            ((CollectionView)sender).SelectedItem = null;
        }

       

           
    }
}