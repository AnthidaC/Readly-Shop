using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;
using System.Linq;
using System;


public class UILoaderDetail : MonoBehaviour
{
    [Header("DetailOfBook")]
    public GameObject bookDetailPage;
    public GameObject Main;
    public Image bookimg;
    public TMP_Text bookName;
    public TMP_Text content;
    public TMP_Text price;
    public TMP_Text type;
    public TMP_Text Author;
    public TMP_Text Publisher;
    private GameObject bookObject;

    private ImageManager imgMana;
    private DataManager dataMana;
    private void Awake()
    {
        imgMana = FindFirstObjectByType<ImageManager>();
        dataMana = FindFirstObjectByType<DataManager>();
    }
    public void ShowBookDetail(Book book, GameObject t)
    {
        bookDetailPage.SetActive(true);
        Main.SetActive(false);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) bookimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else bookimg.sprite = null;
        bookName.text = book.Name;
        price.text = book.Price.ToString();
        type.text = book.TypeBook;
        Author.text = book.Author;
        Publisher.text = book.Publisher;
        content.text = book.Title;
        bookObject = t;
    }
}
    
