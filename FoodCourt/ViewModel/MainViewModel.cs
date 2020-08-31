using FoodCourt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FoodCourt.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public MainViewModel()
        {
            Orders = new ObservableCollection<Food>();
            Foods = GetFoods();
        }
        public float TotalPrice => Orders.Sum(x => x.Price);
        public int OrderCount => Orders.Count;

        private ObservableCollection<Food> foods;

        public ObservableCollection<Food> Foods
        {
            get { return foods; }
            set 
            { 
                foods = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Food> orders;
        public ObservableCollection<Food> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
                OnPropertyChanged(nameof(OrderCount));
            }
        }

        private ObservableCollection<Food> GetFoods()
        {
            return new ObservableCollection<Food>
            {
                new Food{ Name = "Omelette Breakfast Dish", Image = "Omelette.png", Price = 13.99f, Description = "Omelette Breakfast Dish Fried egg. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt"},
                new Food{ Name = "California Sushi pizza", Image = "California.png", Price = 22.59f, Description = "California roll Sushi pizza. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt"},
                new Food{ Name = "Greek Salad with tomatoes", Image = "Greek.png", Price = 18.25f, Description = "Greek Salad with tomatoes. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt"},
                new Food{ Name = "Cherry with pepper salad", Image = "Cherry.png", Price = 10.99f, Description = "Tomato cherry with lettuce and bell pepper salad. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod"},
            };
        }

        public void AddOrder(Food food)
        {
            if(food != null)
            {
                Orders.Add(food);
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

    }
}
