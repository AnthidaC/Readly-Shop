using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Home_maneger : MonoBehaviour
{

    [Header("Home page")]
    public GameObject homePrefab;
    public GameObject homwDetail;
    public Transform Homelist;
    public Image homeimg;
 
    public TMP_Dropdown TypeDropdown;

    private ImageManager_show imgMana;
    private DataManager dataMana;
    private void Awake()
    {
        imgMana = FindFirstObjectByType<ImageManager_show>();
        dataMana = FindFirstObjectByType<DataManager>();
        TypeDropdown.onValueChanged.AddListener(delegate { loadingBook(); });

    }
    public void loadingBook()
    {

        string selectedType = TypeDropdown.options[TypeDropdown.value].text;
        while (Homelist.childCount > 0)
        {
            DestroyImmediate(Homelist.GetChild(0).gameObject);
        }
        foreach (Book bo in DataManager.book.Values)
        {
           
                GameObject clone = Instantiate(homePrefab);
                clone.transform.parent = Homelist;
                clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);
                clone.GetComponent<Homepage>().b = bo;
                clone.GetComponent<Homepage >().Show();
            
        }
        if (DataManager.book.Count > 6)
        {
            Homelist.gameObject.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        print("Hi Page Order");
    }

    public void ShowBookDetail(Book book, GameObject t)
    {
        homwDetail.SetActive(true);
        Texture2D myTexture2D = book.imgBook;
        if (myTexture2D != null) homeimg.sprite = Sprite.Create(myTexture2D, new Rect(0.0f, 0.0f, myTexture2D.width, myTexture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        else homeimg.sprite = null;
    }
}
