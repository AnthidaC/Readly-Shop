using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Onclick : MonoBehaviour
{
    public GameObject bookdetail;
    public GameObject newhome;
    public GameObject besthome;
    public GameObject recomhome;
    public GameObject seachpage;
    public GameObject detail_seach;
    public GameObject header;
    public GameObject home;
    public GameObject view;
    public TMP_InputField searchInputField;
    public TMP_Dropdown dropdown;
    public void click()
    {
        bool isActivedetail = bookdetail.activeSelf;
        bool isActive = seachpage.activeSelf;
        if (isActivedetail)
        {

            newhome.SetActive(true);
            header.SetActive(true);
            besthome.SetActive(true);
            recomhome.SetActive(true);  
            bookdetail.SetActive(false);
            view.GetComponent<ContentSizeFitter>().enabled = false;
            view.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 2000);
            ClearSearch();
            ClearDropdown();

        }
        if (isActive)
        {

            newhome.SetActive(true);
            header.SetActive(true);
            besthome.SetActive(true);
            recomhome.SetActive(true);
            bookdetail.SetActive(false);
            seachpage.SetActive(false);
            view.GetComponent<ContentSizeFitter>().enabled = false;
            view.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 2000);
            ClearSearch();
            ClearDropdown();

        }

    }
    void ClearSearch()
    {
        searchInputField.text = ""; 
    }
    void ClearDropdown()
    {
            dropdown.value = 0;
            dropdown.RefreshShownValue(); 
        
    }
}