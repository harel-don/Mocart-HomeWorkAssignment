using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductUiManager : MonoBehaviour
{
    [Header("Product Panels")]
    [Space(1)]
    [SerializeField] private GameObject productUIPanel; // Panel to be shown/hidden
    [SerializeField] private GameObject[] productUIPanels; // Parent panels for each product
    [SerializeField] private TextMeshProUGUI[] productNameTexts;
    [SerializeField] private TextMeshProUGUI[] productPriceTexts;
    [SerializeField] private TMP_InputField[] nameInputFields;
    [SerializeField] private TMP_InputField[] priceInputFields;
    [SerializeField] private Button[] submitButtons;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Button toggleButton; // Button to open/close the UI

    // Reference to ProductManager
    [SerializeField] private ProductManager productManager;

    private Products[] products;

    void Start()
    {
        // Ensure ProductManager reference is set
        if (productManager == null)
        {
            Debug.LogError("ProductManager is not assigned!");
            return;
        }

        // Initialize the toggle button to show/hide the modification UI panel
        toggleButton.onClick.AddListener(ToggleProductUIPanel);

        // Attach button listeners for each submit button
        for (int i = 0; i < submitButtons.Length; i++)
        {
            int index = i; // Capture the current index for the listener
            submitButtons[i].onClick.AddListener(() => OnSubmitButtonClicked(index));
        }

        // Initialize the UI with the products data from ProductManager
        products = productManager.GetProducts();
        DisplayProducts(products);

        // Hide the panel by default
        productUIPanel.SetActive(false);
    }

    // Function to display products in the UI
    public void DisplayProducts(Products[] products)
    {
        if (products == null || products.Length == 0)
        {
            feedbackText.text = "No products available.";
            feedbackText.color = Color.red;
            return;
        }

        for (int i = 0; i < productUIPanels.Length; i++)
        {
            if (i < products.Length)
            {
                // Show the parent UI panel for the product
                productUIPanels[i].SetActive(true);

                // Update the UI elements within the panel
                productNameTexts[i].text = products[i].name;
                productPriceTexts[i].text = "$" + products[i].price.ToString("F2");
                nameInputFields[i].text = products[i].name;
                priceInputFields[i].text = products[i].price.ToString("F2");
            }
            else
            {
                // Hide the unused parent panel
                productUIPanels[i].SetActive(false);
            }
        }
    }

    // Function called when a submit button is clicked
    private void OnSubmitButtonClicked(int index)
    {
        if (index >= products.Length)
        {
            Debug.LogError("Index out of range for product update.");
            return;
        }

        // Get the new values from the input fields
        string newName = nameInputFields[index].text;
        float newPrice;
        bool isValidPrice = float.TryParse(priceInputFields[index].text, out newPrice);

        if (isValidPrice)
        {
            // Update the product details locally
            products[index].name = newName;
            products[index].price = newPrice;

            // Call the update function in ProductManager to reflect changes globally
            productManager.UpdateProduct(index, products[index]);

            // Provide feedback to the user
            feedbackText.text = "Product updated!";
            feedbackText.color = Color.green;
            Debug.Log($"Product {index + 1} updated: {newName}, ${newPrice}");

            // Refresh the display to show updated data
            DisplayProducts(products);
        }
        else
        {
            feedbackText.text = "Invalid price entered.";
            feedbackText.color = Color.red;
        }
    }

    // Function to toggle the UI panel visibility
    private void ToggleProductUIPanel()
    {
        bool isActive = productUIPanel.activeSelf;
        productUIPanel.SetActive(!isActive);

        if (!isActive)
        {
            products = productManager.GetProducts();
            DisplayProducts(products);
            feedbackText.text = "Modify products shown on the shelf.";
            feedbackText.color = Color.blue;
        }
    }
}
