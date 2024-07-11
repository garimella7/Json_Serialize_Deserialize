// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

Purchase purchase = new Purchase()
{
    ProductName = "AC",
    PurchaseDate = DateTime.Now,
    ProductPrice = 40000
};

// This method is used to serialize the Purchase class into jsonstring
string Json_Serialize(Purchase purchaseObj)
{
    var options = new JsonSerializerOptions();
    options.WriteIndented = true;

    var jsonString = JsonSerializer.Serialize(purchaseObj, options);

    File.WriteAllText("Purchase.json", jsonString);

    return jsonString;
}

// This method is used to construct the Purchase object from the jsonstring
void Json_Deserialize(string jsonString)
{
    Purchase deserializePurchase = JsonSerializer.Deserialize<Purchase>(jsonString);
    
    Console.WriteLine(deserializePurchase.ProductName);
    Console.WriteLine(deserializePurchase.PurchaseDate);
    Console.WriteLine(deserializePurchase.ProductPrice);
}

var jsonString = Json_Serialize(purchase);
Json_Deserialize(jsonString);

[Serializable]
public class Purchase
{
    public string ProductName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public float ProductPrice { get; set; }
}