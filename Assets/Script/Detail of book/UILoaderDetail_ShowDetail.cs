using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class UILoaderDetail : MonoBehaviour
{
    public GameObject UIDetailPage;
    public Image bookimg;
    public TMP_Text bookName;
    public TMP_Text content;
    public TMP_Text price;
    public TMP_Dropdown bookTypeDropdown;
    //public TMP_Text stock;
    //public TMP_Text status;
    public TMP_Text type;
    public TMP_Text Author;
    public TMP_Text Publisher;
    private GameObject bookObject;
    public Book Orderbook;

    public GameObject bookDetailPage;
    public GameObject homeDetailPage;
    private ImageManager imgMana;
    private DataManager dataMana;

    public NumberInDe NumIn;
    

    private void Awake()
    {
        imgMana = FindFirstObjectByType<ImageManager>();
        dataMana = FindFirstObjectByType<DataManager>();
    }
    public void ShowBookDetail(Book book)
    {
        UIDetailPage.SetActive(true);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) bookimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else bookimg.sprite = null;
        bookName.text = book.Name;
        price.text = book.Price.ToString()+"฿";
        //stock.text = book.Stock.ToString();
        type.text = "ประเภท :"+book.TypeBook;
        //status.text = ((statusBook)int.Parse(book.Status)).ToString();
        Author.text = "ผู้เขียน :"+book.Author;
        Publisher.text = "สำนักพิมพ์ :"+book.Publisher;
        content.text = "เรื่องย่อ : \n\n"+book.Title;
        //bookObject = t;
        Orderbook = book;
    }
    public void GoBackToMainPage()
    {
        UIDetailPage.SetActive(false);
        bookDetailPage.SetActive(false);
        homeDetailPage.SetActive(true);
        ResetDropdown();
    }
    public void ResetDropdown()
    {
        bookTypeDropdown.value = 0; 
        bookTypeDropdown.RefreshShownValue(); 
    }

    
    public void Addto()
    {

        DataManager db = FindFirstObjectByType <DataManager> ();
        ToCart cart = FindFirstObjectByType<ToCart> ();
        Receipt rep = FindFirstObjectByType<Receipt>();
        bool i = DataManager.userCart.AddBookToCart(Orderbook, NumIn.ButtonPressIncrease);
        if (i)
        {
            StartCoroutine(db.AddCartData(Orderbook.Id, NumIn.ButtonPressIncrease, value =>
            {
                if (value == 0) {
                    UnityEngine.Debug.LogError("Add cart data error");
                }
                else
                {
                    print("Add cart to database ss");
                    rep.ReceiptBook();
                    cart.CloneCart();
                    
                }
            }));
        }
        else
        {
            int bookId = Orderbook.Id; 
            int newAmount = DataManager.userCart.BooksInCart[Orderbook];
            StartCoroutine(db.ChangeNumBookInCart(bookId, newAmount, value =>
            {
                if (value == 0)
                {
                    UnityEngine.Debug.LogError("ChangeNum cart data error");
                }
                else
                {
                    print("ChangeNum cart to database ss");
                    cart.CloneCart();
                    rep.ReceiptBook();
                }
            }));
        }

    }
    

}
