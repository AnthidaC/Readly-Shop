using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public Book id;

    public void Removebook()
    {
        ToCart pM = FindFirstObjectByType<ToCart>();
        pM.RemoveBook(id.Id);

    }
}
