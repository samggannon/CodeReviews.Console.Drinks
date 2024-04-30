using Newtonsoft.Json;

namespace Drinks.samggannon.Models;

public class Drink
{
    public string idDrink { get; set; }
    public string strDrink { get; set; } = string.Empty;
}

public class DrinksL
{
    [JsonProperty("drinks")]
    public List<Drink> DrinksList { get; set; }
}
