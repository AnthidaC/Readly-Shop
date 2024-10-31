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
using UnityEditor.PackageManager;

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
   

    [Header("Homepage")]
    public GameObject NewPrefab;
    public Transform newlist;
    public TMP_Text newprice;
    public GameObject bestPrefab;
    public Transform bestlist;
    
    public GameObject recomPrefab;
    public Transform recomlist;

    [Header("Foe Seach")]
    public GameObject AllPrefab;
    public Transform Alllist;
    public GameObject homeDetailPage;
    public Image homeimg;
    private int countbookNew;
    private int countbookbest;
    private int countbookre ;
    private ImageManager_show imgMana;
    private DataManager dataMana;

    
    private void Awake()
    {     
        bookTypeDropdown.onValueChanged.AddListener(delegate { loadingBook(); });
        countbookNew = 0;
        countbookbest = 0;
        countbookre = 0;
       
        while (newlist.childCount > 0)
        {
            DestroyImmediate(newlist.GetChild(0).gameObject);
        }
        while (bestlist.childCount > 0)
        {
            DestroyImmediate(bestlist.GetChild(0).gameObject);
        }
        while (recomlist.childCount > 0)
        {
            DestroyImmediate(recomlist.GetChild(0).gameObject);
        }
        while (Alllist.childCount > 0)
        {
            DestroyImmediate(Alllist.GetChild(0).gameObject);
        }
    }
  
    
    public void loadingBook()
    {
       
        string selectedType = bookTypeDropdown.options[bookTypeDropdown.value].text;

        while (Booklist.childCount > 0)
        {
            DestroyImmediate(Booklist.GetChild(0).gameObject);

        }

        /*while (Booklist.childCount > 0)
        {
            DestroyImmediate(Booklist.GetChild(0).gameObject);
           
        }
        while (newlist.childCount > 0)
        {
            DestroyImmediate(newlist.GetChild(0).gameObject);
        }
        while (bestlist.childCount > 0)
        {
            DestroyImmediate(bestlist.GetChild(0).gameObject);
        }
        while (recomlist.childCount > 0)
        {
            DestroyImmediate(recomlist.GetChild(0).gameObject);
        }*/
        foreach (Book bo in DataManager.book.Values)
        {

           
                GameObject clone = Instantiate(AllPrefab);
                clone.transform.parent = Alllist;
                clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                clone.GetComponent<Home_show>().b1 = bo;
                clone.GetComponent<Home_show>().Show_home();
                clone.SetActive(false);
          
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
            else if (bo.Stock < 10 && bo.Stock != 0)
            {
                if (countbookbest < 7)
                {
                    GameObject clone = Instantiate(bestPrefab);
                    clone.transform.parent = bestlist;
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                    clone.GetComponent<Home_show>().b1 = bo;
                    clone.GetComponent<Home_show>().Show_home();
                    countbookbest++;

                }
            }
            else if(bo.Stock > 10)
            {
                if (countbookNew < 7)
                {
                    GameObject clone = Instantiate(NewPrefab);
                    clone.transform.parent = newlist;
                    clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                    clone.GetComponent<Home_show>().b1 = bo;
                    clone.GetComponent<Home_show>().Show_home();
                    countbookNew++;
                    
                }
            }
            else 
            {
                if (countbookre < 7)
                {
                   
                    if (bo.TypeBook == "Horror"|| bo.TypeBook == "Self help" || bo.TypeBook == "Business" || bo.TypeBook == "Non_fiction"|| bo.TypeBook == "Novel" || bo.TypeBook == "Children")
                    {
                            GameObject clone = Instantiate(recomPrefab);
                            clone.transform.parent = recomlist;
                            clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                            clone.GetComponent<Home_show>().b1 = bo;
                            clone.GetComponent<Home_show>().Show_home();
                            countbookre++;
                           
                    }
                    
                }
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
    public void ShowHomeDetail(Book book, GameObject t)
    {
        
        homeDetailPage.SetActive(true);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) homeimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else homeimg.sprite = null;
        price.text = book.Price.ToString();
        bookObject = t;
    }
   


}