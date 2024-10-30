using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCart : MonoBehaviour
{
    public Book book;
    public NumberInDe NumIn;

    public void Addto()
    {
        ToCart pM = FindFirstObjectByType<ToCart>();
        pM.AddBook(book, NumIn.ButtonPressIncrease);

    }

}
