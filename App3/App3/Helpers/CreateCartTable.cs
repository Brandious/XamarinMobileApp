using App3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3.Helpers
{
    public class CreateCartTable

    {
        public bool CreateTable()
        {
            try
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                cn.CreateTable<CartItem>();
                cn.Close();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
