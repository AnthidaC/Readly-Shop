using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DetailOfBook : MonoBehaviour
{
    public Book b;
    public TMP_Text price;
    public TMP_Text nam;
    public Image image;
    public TMP_Text type;
    public TMP_Text Author;
    public TMP_Text Publisher;
    public TMP_Text content;



    public void Show()
    {
        nam.text = b.Name;
        price.text = b.Price.ToString() + " ฿";
        type.text = b.TypeBook;
        Author.text = b.Author;
        Publisher.text = b.Publisher;
        content.text = b.Title;
        Texture2D myTexture2D = b.imgBook;
        if (myTexture2D != null) image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public void detail()
    {
        UILoaderDetail pM = FindFirstObjectByType<UILoaderDetail>();
        pM.ShowBookDetail(b, this.gameObject);

    }

    public void OnClick()
    {
        UILoaderDetail bookPage = FindFirstObjectByType<UILoaderDetail>();

        bookPage.ShowBookDetail(b, this.gameObject);
    }
}
