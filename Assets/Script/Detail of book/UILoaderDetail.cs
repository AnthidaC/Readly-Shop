using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

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

    public GameObject bookDetailPage;
    public GameObject homeDetailPage;
    private ImageManager imgMana;
    private DataManager dataMana;
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
        content.text = "เรื่องย่อ : \n"+book.Title;
        //bookObject = t;
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
}
