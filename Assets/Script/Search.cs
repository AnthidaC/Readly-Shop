using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SearchBook : MonoBehaviour
{
    public Transform Booklist;
    public TMP_InputField ser;
  

    // Update is called once per frame
    public void search()
    {
        int l = 0;
        for (int i = 0; i < Booklist.childCount; i++)
        {
            if (string.IsNullOrEmpty(ser.text))
            {
                Booklist.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                if (Booklist.childCount > 6)
                {
                    Booklist.GetComponent<ContentSizeFitter>().enabled = false;
                    Booklist.GetComponent<RectTransform>().sizeDelta = new Vector2(1925, 680);
                }
                GameObject g = Booklist.GetChild(i).gameObject;
                if (g.GetComponent<book>().b.ToString().Contains(ser.text))
                {
                    g.SetActive(true);
                    l++;
                }
                else g.SetActive(false);

            }
        }
        if (l > 6)
        {

            Booklist.GetComponent<ContentSizeFitter>().enabled = true;
        }
    }
}
