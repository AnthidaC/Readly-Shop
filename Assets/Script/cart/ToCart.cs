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
    public NumberInDe NumOfCart;
    public TextMeshProUGUI numbertext;
    int sum = 0;
    int n = 0;

    [Header("CloneCart")]
    public Book c;
    public Book book;
    public GameObject NewPrefab;
    public Transform newlist;
    private int countbook = 0;

    public void ButtonPressAdd(int n)
    {
        Debug.Log("Call me");
        sum = sum + n;
        numbertext.text = sum + "";
    }

    public void CloneCart()
    {
        while (newlist.childCount > 0)
        {
            DestroyImmediate(newlist.GetChild(0).gameObject);
        }
        this.sum = 0;
        countbook = 0;
        Receipt rep = FindFirstObjectByType<Receipt>();
        foreach (var entry in DataManager.userCart.BooksInCart)
        {
            Book bo = entry.Key;
            GameObject clone = Instantiate(NewPrefab);
            clone.transform.parent = newlist;
            clone.GetComponent<RectTransform>().sizeDelta = new Vector2(270, 100);
            clone.GetComponent<DetailOfCart>().book = bo;
            clone.GetComponent<DetailOfCart>().Show();
            countbook+=entry.Value;
        }
        if (DataManager.book.Count > 6)
        {
            newlist.gameObject.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        print("Hi Page Order");
        ButtonPressAdd(countbook);
        rep.ReceiptBook();

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
}

