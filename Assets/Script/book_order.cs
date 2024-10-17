using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class book_order : MonoBehaviour
{
    public Book b;
    public TMP_Text price;
    public TMP_Text name;
    public Image image;

    public void Show()
    {
        name.text = b.Name;
        price.text = b.Price.ToString();
        Texture2D myTexture2D = b.imgBook;
        if (myTexture2D != null) image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public void detail()
    {
        Manager_order pM = FindFirstObjectByType<Manager_order>();
        pM.ShowBookDetail(b, this.gameObject);

    }
}