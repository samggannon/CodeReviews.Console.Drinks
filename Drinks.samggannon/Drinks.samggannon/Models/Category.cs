using Newtonsoft.Json;

namespace Drinks.samggannon.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string strCategory { get; set; } = string.Empty;
}

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category> CategoriesList { get; set; }
}
