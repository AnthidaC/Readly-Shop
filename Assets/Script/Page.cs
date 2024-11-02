using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookStore : MonoBehaviour
{
    public TMP_Dropdown categoryDropdown;
    public List<GameObject> bookCategories = new List<GameObject>();


    public void OnCategoryChanged(int index)
    {
        foreach (GameObject category in bookCategories)
        {
            category.SetActive(false);
        }
       
            bookCategories[index].SetActive(true);
        
       
    }
}
