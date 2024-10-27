using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class Bookclick : MonoBehaviour
{
    public GameObject ShoppingPage;
    public GameObject HomePage;
    public Book book;
    public TMP_Text price;
    public TMP_Text stock;
    public TMP_Text name;
    public Image image;
   
    void Start()
    {
        
    
        if (HomePage == null)
        {
            HomePage = GameObject.Find("homeBook");
        }
    }
    public void Onclick()
    {
        print("Onclick function is called.");
        ShoppingPage.SetActive(true);
        HomePage.SetActive(false);
    }
    public void Show()
    {
        name.text = book.Name;
        price.text = book.Price.ToString();
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public void BookDetailforshop()
    {
        maneger_show Sh = new maneger_show();
        Sh.SHoppingpageDetail(book, this.gameObject);
    }
}
