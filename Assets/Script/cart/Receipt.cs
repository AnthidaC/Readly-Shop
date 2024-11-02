using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Receipt : MonoBehaviour
{
    public TMP_Text Total;
    public void ReceiptBook()
    {
        int totalSum = 0;
        for (int i = 0; i < DataManager.userCart.BooksInCart.Count; i++)
        {
            
            int SumofBook = DataManager.userCart.BooksInCart.ElementAt(i).Key.Price * DataManager.userCart.BooksInCart.ElementAt(i).Value;
            totalSum = totalSum + SumofBook;
        }
        Total.text = totalSum.ToString() + " ฿";

    }
}
