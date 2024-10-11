using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookStore : MonoBehaviour
{
    public TMP_Dropdown categoryDropdown;
    public List<GameObject> bookCategories = new List<GameObject>();

    private void Start()
    {
        // แสดงหมวดหมู่เริ่มต้นเมื่อเริ่มเกม
        if (bookCategories.Count > 0)
        {
            OnCategoryChanged(categoryDropdown.value); // แสดงหมวดหมู่เริ่มต้น
        }
    }

    public void OnCategoryChanged(int index)
    {
        foreach (GameObject category in bookCategories)
        {
            category.SetActive(false);
        }
        if(index == 0)
        {
            bookCategories[0].SetActive(true);
        }
        if (index == 1)
        {
            bookCategories[1].SetActive(true);
            
        }
    }
}
