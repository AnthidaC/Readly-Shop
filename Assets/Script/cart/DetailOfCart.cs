using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class DetailOfCart : MonoBehaviour
{
    public Book c;
    public Image image;
    public TMP_Text title;
    public TMP_Text type;
    public TMP_Text price;

    public void Show()
    {
        title.text = c.Name;
        type.text = c.TypeBook;
        price.text = c.Price.ToString();
        Texture2D myTexture2D = c.imgBook;
        if (myTexture2D != null) 
            image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public void detail()
    {
        UILoaderCart pM = FindFirstObjectByType<UILoaderCart>();
        pM.ShowBookDetail(c, this.gameObject);

    }

}

