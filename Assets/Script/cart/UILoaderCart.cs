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

public class UILoaderCart : MonoBehaviour
{
    public Image bookimg;
    public TMP_Text bookName;
    public TMP_Text bookType;
    public TMP_Text price;

    public void ShowBookDetail(Book book, GameObject t)
    {
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null)
            bookimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else
            bookimg.sprite = null;

        bookName.text = book.Name;
        bookType.text = book.TypeBook;
        price.text = book.Price.ToString();
    }
}
    
