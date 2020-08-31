using FoodCourt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodCourt
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OpenOrderTab(object sender, EventArgs e)
        {
            if (OrderView.TranslationX >= 150)
            {
                Action<double> callback = input => OrderView.TranslationX = input;
                OrderView.Animate("orderAnim", callback, 150, 0, 16, 300, Easing.CubicInOut);
            }
        }

        private void AddOrder(object sender, EventArgs e)
        {
            var order = ((sender as Button).BindingContext) as Food;
            vm.AddOrder(order);
        }
        
        private void CloseOrder(object sender, EventArgs e)
        {
            if (OrderView.TranslationX == 0)
            {
                Action<double> callback = input => OrderView.TranslationX = input;
                OrderView.Animate("orderAnim", callback, 0, 150, 16, 300, Easing.CubicOut);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            closeTab();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            closeTab();
        }

        private void closeTab()
        {
            if (OrderView.TranslationX >= 150)
                return;
            Action<double> callback = input => OrderView.TranslationX = input;
            OrderView.Animate("orderAnim", callback, 0, 150, 16, 300, Easing.CubicOut);
        }
    }
}
