using System;

/// <summary>
/// Represents a product with a name, description, and price.
/// </summary>
[System.Serializable]
public class Products
{
    /// <summary>
    /// Name of the product.
    /// </summary>
    public string name;

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string description;

    /// <summary>
    /// Price of the product.
    /// </summary>
    public float price;
}

/// <summary>
/// Represents a response from the product API, containing an array of products.
/// </summary>
[System.Serializable]
public class ProductResponse
{
    /// <summary>
    /// Array of products included in the API response.
    /// </summary>
    public Products[] products;
}
