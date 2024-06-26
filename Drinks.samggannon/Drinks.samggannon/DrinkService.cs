﻿using Newtonsoft.Json;
using RestSharp;
using Drinks.samggannon.Models;
using System.Web;
using System.Reflection;

namespace Drinks.samggannon;

public class DrinkService
{
    private string baseUrl = "http://www.thecocktaildb.com/api/json/v1/1/";
    public List<Category> GetCategories()
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest("list.php?c=list");
        var response = client.ExecuteAsync(request);

        List<Category> categories = new List<Category>();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

            categories = serialize.CategoriesList;
            TableVisualization.ShowTable(categories, "Categories Menu");
        }

        return categories;
    }

    internal List<Drink> GetDrinksByCategory(string? category)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
        var response = client.ExecuteAsync(request);

        List<Drink> drinks = new List<Drink>();

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinksL>(rawResponse);

            drinks = serialize.DrinksList;
            TableVisualization.ShowTable(drinks, "Drinks Menu");
        }

        return drinks;
    }

    internal void GetDrink(string drink)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest($"lookup.php?i={drink}");
        var response = client.ExecuteAsync(request);

        if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            string rawResponse = response.Result.Content;
            var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

            List<DrinkDetail> returnedList = serialize.DrinkDetailList;
            DrinkDetail drinkDetail = returnedList[0];
            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
            {
                if (prop.Name.Contains("str"))
                {
                    formattedName = prop.Name.Substring(3);
                }

                if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                {
                    prepList.Add(new
                    {
                        Key = formattedName,
                        Value = prop.GetValue(drinkDetail)
                    });
                }
            }

            TableVisualization.ShowTable(prepList, drinkDetail.strDrink);
        }
    }
}
