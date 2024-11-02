using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public Book id;
    public void Removebook()
    {
        Cart pM = DataManager.userCart;
        pM.RemoveBookFromCart(id.Id);

    }
}
