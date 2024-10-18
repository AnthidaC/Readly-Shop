using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Homepage : MonoBehaviour
{
    public Book b;
    public Image image;

    public void Show()
    {
        Texture2D myTexture2D = b.imgBook;
        if (myTexture2D != null) image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public void detail()
    {
        maneger_show pM = FindFirstObjectByType<maneger_show>();
        pM.ShowBookDetail(b, this.gameObject);

    }
}
