using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

/// <summary>
/// Manages the retrieval and display of products on the shelf.
/// </summary>
public class ProductManager : MonoBehaviour
{
    private const string apiUrl = "https://homework.mocart.io/api/products";

    [Header("Product Panels")]
    [SerializeField] private TMP_Text[] productNameTexts;
    [SerializeField] private TMP_InputField[] productNameInputs;
    [SerializeField] private TMP_Text[] productPriceTexts;
    [SerializeField] private TMP_InputField[] productPriceInputs;
    [SerializeField] private TMP_Text[] productDescriptionTexts;

    [Header("Product and Shelf")]
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private Transform shelf;

    private Products[] products;
    private GameObject[] productInstances;

    private void Start()
    {
        StartCoroutine(FetchProductData());
    }

    /// <summary>
    /// Coroutine to fetch product data from the API.
    /// </summary>
    private IEnumerator FetchProductData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching product data: " + request.error);
            }
            else
            {
                string jsonResponse = request.downloadHandler.text;
                ProductResponse productResponse = JsonUtility.FromJson<ProductResponse>(jsonResponse);
                products = productResponse.products;

                if (products != null && products.Length > 0)
                {
                    DisplayProducts(products);
                }
                else
                {
                    Debug.LogWarning("No products were parsed from the response.");
                }
            }
        }
    }

    /// <summary>
    /// Displays products on the shelf by instantiating product prefabs.
    /// </summary>
    /// <param name="products">Array of products to display.</param>
    private void DisplayProducts(Products[] products)
    {
        productInstances = new GameObject[products.Length];

        for (int i = 0; i < products.Length; i++)
        {
            // Instantiate a new product prefab as a child of the shelf
            productInstances[i] = Instantiate(productPrefab, shelf);

            // Set the position of each product on the shelf based on the index
            productInstances[i].transform.localPosition = new Vector3(
                i * 2.0f - shelf.right.x * 2, 
                shelf.up.y, 
                shelf.position.z
            );

            // Get references to UI elements inside the prefab
            var productUI = productInstances[i].GetComponent<CubeTextManager>();
            TMP_Text nameText = productUI.GetNameGameObject().GetComponent<TMP_Text>();
            TMP_Text priceText = productUI.GetPriceGameObject().GetComponent<TMP_Text>();
            TMP_Text descriptionText = productUI.GetDescriptionGameObject().GetComponent<TMP_Text>();

            // Set the text values for the product
            nameText.text = products[i].name;
            priceText.text = "$" + products[i].price.ToString("F2");
            descriptionText.text = products[i].description;
        }
    }

    /// <summary>
    /// Updates a specific product's data in the UI and model.
    /// </summary>
    /// <param name="index">Index of the product to update.</param>
    public void UpdateProduct(int index)
    {
        if (index >= products.Length) return;

        products[index].name = productNameInputs[index].text;
        products[index].price = float.Parse(productPriceInputs[index].text);

        var productUI = productInstances[index].GetComponent<CubeTextManager>();
        productNameTexts[index].text = products[index].name;
        productUI.SetName(products[index].name);
        productPriceTexts[index].SetText("$" + products[index].price.ToString("F2"));
    }

    /// <summary>
    /// Updates a specific product with new data and refreshes the UI.
    /// </summary>
    /// <param name="index">Index of the product to update.</param>
    /// <param name="updatedProduct">Updated product data.</param>
    public void UpdateProduct(int index, Products updatedProduct)
    {
        if (index >= 0 && index < products.Length)
        {
            products[index] = updatedProduct;

            var productUI = productInstances[index].GetComponent<CubeTextManager>();
            productUI.SetName(products[index].name);
            productUI.SetPrice(products[index].price.ToString("F2"));
        }
    }

    /// <summary>
    /// Returns the array of products.
    /// </summary>
    /// <returns>Array of products.</returns>
    public Products[] GetProducts()
    {
        return products;
    }
}
