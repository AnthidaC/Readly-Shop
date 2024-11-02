using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions; 

public class Manager_order : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject bookPrefab;
    public Transform contentPanel;
    public Toggle orderToggle; 
    public Button orderButton;
    public AddressManager addressManager; 
    public GameObject toPayPage; 
    public GameObject ordersuccessPage;
    public TextMeshProUGUI totalSumText; 
    public TextMeshProUGUI finalSumText; 
 
    

    private void Start()
    {
        dataManager = FindFirstObjectByType<DataManager>();
        StartCoroutine(GetAndDisplayCartOrder());
        orderToggle.onValueChanged.AddListener(OnToggleChanged);
        orderButton.onClick.AddListener(OnOrderButtonClicked); 
        UpdateOrderButtonState();
    }

    private IEnumerator GetAndDisplayCartOrder()
    {
        yield return dataManager.GetCartData();

        if (DataManager.userCart != null && DataManager.userCart.BooksInCart != null && DataManager.userCart.BooksInCart.Count > 0)
        {
            StartCoroutine(DisplayCartItems()); 
            Debug.Log("มีข้อมูลในตะกร้า");
        }
        else
        {
            Debug.Log("ไม่มีข้อมูลในตะกร้า");
        }
    }

   private IEnumerator DisplayCartItems()
   {
       Debug.Log("Displaying cart items");

       if (contentPanel == null )
       {
           Debug.LogError("contentPanel or bookPrefab is missing.");
           yield break;
       }

       foreach (Transform child in contentPanel)
       {
           if (child != null && child.gameObject != null)
           {
               Destroy(child.gameObject);
               yield return null; 
           }
       }

        float totalSum = 0;
        int bookCount = 0;
       foreach (var item in DataManager.userCart.BooksInCart)
       {
           if (bookPrefab != null)
           {
               GameObject bookInstance = Instantiate(bookPrefab, contentPanel);

               Book bookData = item.Key; 

               string decodedName = Regex.Unescape(bookData.Name); 

               Debug.Log("Book Title: " + decodedName);
            
               TMP_Text nameText = bookInstance.transform.Find("name")?.GetComponent<TMP_Text>();
               TMP_Text priceText = bookInstance.transform.Find("price")?.GetComponent<TMP_Text>();
               TMP_Text amountText = bookInstance.transform.Find("amount")?.GetComponent<TMP_Text>();
               TMP_Text sumText = bookInstance.transform.Find("sum")?.GetComponent<TMP_Text>();
               TMP_Text finalsumText = bookInstance.transform.Find("finalsum")?.GetComponent<TMP_Text>();
               TMP_Text totalsumText = bookInstance.transform.Find("totalsum")?.GetComponent<TMP_Text>(); 
               Image bookImage = bookInstance.transform.Find("Image")?.GetComponent<Image>();

               if (nameText != null) nameText.text = decodedName; 
               if (priceText != null) priceText.text = "ราคา: " + bookData.Price.ToString() + " บาท"; 
               if (amountText != null) amountText.text = "จำนวน: " + item.Value.ToString(); 

                int sum = bookData.Price * item.Value; 
                if (sumText != null) sumText.text = "รวม: " + sum.ToString() + " บาท";
                totalSum += sum;

            
               if (bookImage != null && bookData.imgBook != null)
               {
                   Sprite sprite = Sprite.Create(bookData.imgBook, new Rect(0, 0, bookData.imgBook.width, bookData.imgBook.height), new Vector2(0.5f, 0.5f));
                   bookImage.sprite = sprite;
               }
               bookCount++;
           }
           else
           {
               Debug.LogError("bookPrefab is missing, cannot instantiate book instance.");
           }

           yield return null; 
       }
       

        TMP_Text totalSumText = GameObject.Find("totalsum")?.GetComponent<TMP_Text>();
        TMP_Text finalSumText = GameObject.Find("finalsum")?.GetComponent<TMP_Text>();
        float shippingCost = 80; 
        float finalTotal = totalSum + shippingCost;
        if (totalSumText != null)
        {
            totalSumText.text =  totalSum.ToString() + " บาท";
        }

        if (finalSumText != null)
        {
            finalSumText.text =  finalTotal.ToString() + " บาท";
        }
        
   }
    private void OnToggleChanged(bool isOn)
    {
        UpdateOrderButtonState();
    }

    private void UpdateOrderButtonState()
    {
        orderButton.interactable = orderToggle.isOn;
    }

   private void OnOrderButtonClicked()
{
   
    string address = addressManager.Address;

    StartCoroutine(dataManager.CreateOrder(address, DataManager.userCart.BooksInCart, v =>
    {
        OnOrderCreated(v);
    }));
}

private void OnOrderCreated(int status)
{
    if (status == 1) 
    {
        ordersuccessPage.SetActive(true);
        
        StartCoroutine(dataManager.DeleteAllBookInCart(v=>{

            OnDeleteCartCompleted(v);
            toPayPage.SetActive(false);
        }));
            
    }
    else
    {
        Debug.LogError("การสร้างคำสั่งซื้อล้มเหลว");
    }
}

private void OnDeleteCartCompleted(int status)
{
    if (status == 1)
    {
            DataManager.book.Clear();
            dataManager.GetNormalData();
            ToCart cart = FindAnyObjectByType<ToCart>();
            cart.CloneCart();
            Debug.Log("ลบข้อมูลในตะกร้าเรียบร้อยแล้ว");
    }
    else
    {
        Debug.LogError("การลบข้อมูลในตะกร้าล้มเหลว");
    }
}

}
