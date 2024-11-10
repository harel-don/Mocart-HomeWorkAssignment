using UnityEngine;
using TMPro;

/// <summary>
/// Manages the text components for a product cube, including name, price, and description.
/// </summary>
public class CubeTextManager : MonoBehaviour
{
    [Header("Product UI Elements")]
    [SerializeField] private GameObject ProductName;
    [SerializeField] private GameObject ProductPrice;
    [SerializeField] private GameObject ProductDescription;

    private TMP_Text nameText;
    private TMP_Text priceText;
    private TMP_Text descriptionText;

    /// <summary>
    /// Initializes the text components when the script starts.
    /// </summary>
    private void Start()
    {
        InitTexts();
    }

    /// <summary>
    /// Initializes the TMP_Text references for the product UI.
    /// </summary>
    private void InitTexts()
    {
        nameText = GetNameGameObject().GetComponent<TMP_Text>();
        priceText = GetPriceGameObject().GetComponent<TMP_Text>();
        descriptionText = GetDescriptionGameObject().GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Returns the GameObject for the product name UI element.
    /// </summary>
    /// <returns>GameObject for product name</returns>
    public GameObject GetNameGameObject()
    {
        return ProductName;
    }

    /// <summary>
    /// Returns the GameObject for the product price UI element.
    /// </summary>
    /// <returns>GameObject for product price</returns>
    public GameObject GetPriceGameObject()
    {
        return ProductPrice;
    }

    /// <summary>
    /// Returns the GameObject for the product description UI element.
    /// </summary>
    /// <returns>GameObject for product description</returns>
    public GameObject GetDescriptionGameObject()
    {
        return ProductDescription;
    }

    /// <summary>
    /// Sets the text for the product name.
    /// </summary>
    /// <param name="name">Name of the product</param>
    public void SetName(string name)
    {
        nameText.text = name;
    }

    /// <summary>
    /// Sets the text for the product price using a float value.
    /// </summary>
    /// <param name="price">Price of the product</param>
    public void SetPrice(float price)
    {
        priceText.text = "$" + price.ToString("F2");
    }

    /// <summary>
    /// Sets the text for the product price using a string value.
    /// </summary>
    /// <param name="price">Price of the product as a string</param>
    public void SetPrice(string price)
    {
        priceText.text = "$" + price;
    }

    /// <summary>
    /// Sets the text for the product description.
    /// </summary>
    /// <param name="description">Description of the product</param>
    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }
}
