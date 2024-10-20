using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Home_show : MonoBehaviour
{
    public Book b1;
    public Image image;
    public TMP_Text price;
    public TMP_Text name;
    public void Show_home()
    {
 
        //name.text = b1.Name;
        //price.text = b1.Price.ToString();
        Texture2D myTexture2D = b1.imgBook;
        if (myTexture2D != null) image.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
    public void detail()
    {
        maneger_show pM = FindFirstObjectByType<maneger_show>();
        pM.ShowHomeDetail(b1, this.gameObject);

    }
}
