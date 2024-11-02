using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Change_types : MonoBehaviour
{
    public TMP_Dropdown categoryDropdown;
    public List<GameObject> bookCategories = new List<GameObject>();

    private void Start()
    {

        if (bookCategories.Count > 0)
        {
            OnCategoryChanged(categoryDropdown.value);
        }
    }

    public void OnCategoryChanged(int index)
    {
        foreach (GameObject category in bookCategories)
        {
            category.SetActive(false);
        }

        bookCategories[index].SetActive(true);


    }
}
