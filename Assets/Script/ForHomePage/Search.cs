using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Search : MonoBehaviour
{
    public Transform Booklist;
    public TMP_InputField ser;
    public TMP_Dropdown type;

    public void search()
    {
        int l = 0;
        string searchText = ser.text.Trim().ToLower(); 
        for (int i = 0; i < Booklist.childCount; i++)
        {
            GameObject g = Booklist.GetChild(i).gameObject;
            var book = g.GetComponent<book_show>().b;

            if (book == null)
            {
                Debug.Log("book_show component missing or 'b' is null on: " + g.name);
                continue;
            }

          
            if (string.IsNullOrEmpty(searchText) && type.value == 0)
            {
                g.SetActive(true);
            }
            else
            {
                if (Booklist.childCount > 6)
                {
                    Booklist.GetComponent<ContentSizeFitter>().enabled = false;
                    Booklist.GetComponent<RectTransform>().sizeDelta = new Vector2(1925, 680);
                }

                bool matchesSearch = book.Name.ToLower().Contains(searchText);
                bool matchesType = ((typeBook)(type.value - 1)).ToString() == book.TypeBook || type.value == 0;

               
                if (matchesSearch || matchesType)
                {
                    g.SetActive(true);
                    l++;
                }
                else
                {
                    g.SetActive(false);
                }
            }
        }

        if (l > 6)
        {
            Booklist.GetComponent<ContentSizeFitter>().enabled = true;
        }
    }
}


