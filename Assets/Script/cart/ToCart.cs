using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;
using System.Linq;
using System;
public class ToCart : MonoBehaviour
{
    [Header("DetailOfBook")]
    public GameObject bookDetailPage;
    public Image bookimg;
    public TMP_Text bookName;
    public TMP_Text price;
    public TMP_Text type;
    private GameObject bookObject;

    [Header("CountAdd")]
    public NumberInDe NumIn;
    public TextMeshProUGUI numbertext;
    public int AllOrder = 0;
    public int n = 0;

    [Header("CloneCart")]
    public Book c;
    public Book book;
    public GameObject NewPrefab;
    public Transform newlist;
    private int countbook = 0;

    [Header("Addtocart")]
    public Book id;
    private int cartID;
    private Dictionary<Book, int> booksInCart = new Dictionary<Book, int>();

    public int CartID { get => cartID; set => cartID = value; }
    public Dictionary<Book, int> BooksInCart { get => booksInCart; set => booksInCart = value; }

    public ToCart(int cartID)
    {
        this.CartID = cartID;
    }

    public void ButtonPressAdd ()
    {
        n = NumIn.ButtonPressIncrease;
        AllOrder = AllOrder + n;
        numbertext.text = AllOrder + "";
    }

    public void CloneCart ()
    {
        while (newlist.childCount > 0)
        {
            DestroyImmediate(newlist.GetChild(0).gameObject);
        }

        foreach (Book bo in DataManager.book.Values)
        {
            GameObject clone = Instantiate(NewPrefab);
            clone.transform.parent = newlist;
            clone.GetComponent<RectTransform>().sizeDelta = new Vector2(270,100);
            clone.GetComponent<DetailOfCart>().book = bo;
            clone.GetComponent<DetailOfCart>().Show();
            countbook++;
        }

        if (DataManager.book.Count > 6)
        {
            newlist.gameObject.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        print("Hi Page Order");

    }

    
    public void DetailOfBook(Book book, GameObject t)
    {
            bookDetailPage.SetActive(true);
            Texture2D myTexture2D = book.imgBook;
            if (myTexture2D != null) bookimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
            else bookimg.sprite = null;
            bookName.text = book.Name;
            price.text = book.Price.ToString();
            type.text = book.TypeBook;
            bookObject = t;
    }

    public bool AddBook(Book book, int amount)
    {
        print("In AddBook");
        print(book);
            for (int i = 0; i < this.booksInCart.Count; i++)
            {
                if (booksInCart.ElementAt(i).Key.Id == book.Id)
                {
                    print("Book in cart");
                    return true;
                }
            }
        booksInCart.Add(book, amount);
        CheckAmountBookFromCart(id.Id, amount);
        return true;
    }

    public void CheckAmountBookFromCart(int bookId, int amount)
    {
        print("Check AmountBook");
        for (int i = 0; i < this.booksInCart.Count; i++)
        {
            if (booksInCart.ElementAt(i).Key.Id == bookId)
            {
                booksInCart[(booksInCart.ElementAt(i).Key)] = amount;
            }
        }
    }

    public void RemoveBook(int bookID)
    {
        print("In Remove");
        for (int i = 0; i < this.booksInCart.Count; i++)
        {
            if (booksInCart.ElementAt(i).Key.Id == bookID)
            {
                booksInCart.Remove(booksInCart.ElementAt(i).Key);
            }
        }
    }
    public void Clear()
    {
        this.booksInCart = null;
    }




}

