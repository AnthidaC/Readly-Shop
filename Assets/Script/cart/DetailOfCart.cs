using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class DetailOfCart : MonoBehaviour
{
    public Book book;
    public Image image;
    public TMP_Text title;
    public TMP_Text type;
    public TMP_Text price;
    public TMP_Text count;


    public int amount = 0;

    public void Show()
    {
        title.text = book.Name;
        type.text = book.TypeBook;
        price.text = book.Price.ToString() + " ฿";
        count.text = DataManager.userCart.BooksInCart[book].ToString() + " เล่ม";
        ToCart pM = FindFirstObjectByType<ToCart>();
        pM.ButtonPressAdd(DataManager.userCart.BooksInCart[book]);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) 
            image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public void detail()
    {
        ToCart pM = FindFirstObjectByType<ToCart>();
        pM.DetailOfBook(book, this.gameObject);
       
    }

    public void Removebook()
    {
        Receipt rep = FindFirstObjectByType<Receipt>();
        DataManager.userCart.RemoveBookFromCart(book.Id);
        DataManager db = FindFirstObjectByType<DataManager>();
        ToCart cart = FindAnyObjectByType <ToCart>();
        int bookId = book.Id;
        StartCoroutine(db.DeleteBookInCart(bookId, value =>
        {
            if (value == 0)
            {
                UnityEngine.Debug.LogError("Delete cart data error");
            }
            else
            {
                print("Delete cart to database ss");
                cart.CloneCart();
                rep.ReceiptBook();
            }
        }));

    }

}

