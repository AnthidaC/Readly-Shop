using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Collections.AllocatorManager;
using System.Linq;
using System;
using Unity.VisualScripting;
using System.ComponentModel.Design;
using System.Reflection;

public class maneger_show : MonoBehaviour
{
    [Header("Book page")]
    public GameObject BookPrefab;
    public Transform Booklist;

    public GameObject bookDetailPage;
    public Image bookimg;
    public TMP_Text bookName;
    public TMP_Text price;
    public TMP_Dropdown bookTypeDropdown;
    private GameObject bookObject;
    private ImageManager_show imgMana;
    private DataManager dataMana;
    private void Awake()
    {
        imgMana = FindFirstObjectByType<ImageManager_show>();
        dataMana = FindFirstObjectByType<DataManager>();
        bookTypeDropdown.onValueChanged.AddListener(delegate { loadingBook(); });
        
    }
    public void loadingBook()
    {

        string selectedType = bookTypeDropdown.options[bookTypeDropdown.value].text;
        while (Booklist.childCount > 0)
        {
            DestroyImmediate(Booklist.GetChild(0).gameObject);
        }
        foreach (Book bo in DataManager.book.Values)
        {
            if (bo.TypeBook == selectedType)
            {
                GameObject clone = Instantiate(BookPrefab);
                clone.transform.parent = Booklist;
                clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                clone.GetComponent<book_show>().b = bo;
                clone.GetComponent<book_show>().Show();
            }
        }
        if (DataManager.book.Count > 6)
        {
            Booklist.gameObject.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        print("Hi Page Order");
    }

    public void ShowBookDetail(Book book, GameObject t)
    {
        bookDetailPage.SetActive(true);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) bookimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else bookimg.sprite = null;
        bookName.text = book.Name;
        price.text = book.Price.ToString();
        bookObject = t;
    }

}