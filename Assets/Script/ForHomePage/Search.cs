using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Search : MonoBehaviour
{
    public Transform Booklist;
    public Transform contant;
    public GameObject view;
    public Transform Newlist;
    public Transform Relist;
    public Transform hotlist;
    public Transform Header;
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
    
    public void searchHome()
    {
        int l = 0;
        
    string searchText = ser.text.Trim().ToLower();
        
        for (int i = 0; i < Booklist.childCount ; i++)
        {
            GameObject g = Booklist.GetChild(i).gameObject;
            GameObject g1 = Newlist.gameObject;
            GameObject g2 = Relist.gameObject;
            GameObject g3 = hotlist.gameObject;
            GameObject h = Header.gameObject;
            var book = g.GetComponent<Home_show>().b1;
            
            if (book == null)
            {
                Debug.Log("book_show component missing or 'b' is null on: " + g.name);
                continue;
            }


            if (string.IsNullOrEmpty(searchText) && type.value == 0)
            {
                g.SetActive(true);
                g1.SetActive(true);
                g2.SetActive(true);
                g3.SetActive(true);
                h.SetActive(true);

            }
            else
            {


                bool matchesSearch = book.Name.ToLower().Contains(searchText);


                if (matchesSearch)
                {
                  
                    g.SetActive(true);
                    g1.SetActive(false);
                    g2.SetActive(false);
                    g3.SetActive(false);
                    h.SetActive(false);
                    l++;
                   
                    
                }
                else
                {

                    g.SetActive(false);
                }
               
            }
           
        }
       
    }
        }

    
    






