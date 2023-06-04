﻿using ClassLibrary;
using DrinksInfo.API;
using DrinksInfo.Models;

namespace DrinksInfo.View
{
    public static class CategoriesView
    {
        internal static void SelectCategory()
        {
            List<Category> list = CategoriesAPI.GetDrinkCategories();

            Console.Write("Choose Category or type 0 to leave the program: ");

            var choice = Console.ReadLine();

            string drink = choice switch
            {
                "1" => HelperMethods.filterString(list[0].GetName()),
                "2" => HelperMethods.filterString(list[1].GetName()),
                "3" => HelperMethods.filterString(list[2].GetName()),
                "4" => HelperMethods.filterString(list[3].GetName()),
                "5" => HelperMethods.filterString(list[4].GetName()),
                "6" => HelperMethods.filterString(list[5].GetName()),
                "7" => HelperMethods.filterString(list[6].GetName()),
                "8" => HelperMethods.filterString(list[7].GetName()),
                "9" => HelperMethods.filterString(list[8].GetName()),
                "10" => HelperMethods.filterString(list[9].GetName()),
                "11" => HelperMethods.filterString(list[10].GetName()),
                "0" => "0",
                _ => "This category dosn't exist, select a visible one"
            }; ;

            if (drink == "0")
            {
                Console.Clear();
                Console.WriteLine("Bye");
                Environment.Exit(0);
                return;
            }
            else if (drink == "This category dosn't exist, select a visible one")
            {
                Console.WriteLine(drink);
            }
            else
            {
                DrinksListView.SelectDrink(drink.Trim());
            }
        }
    }
}
