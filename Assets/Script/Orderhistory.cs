using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Orderhistory : MonoBehaviour
{
    public Manager_order managerOrder; 
    public Transform Orderlist; 
    public GameObject OrderPrefab; 
    public GameObject orderDetail; 
    private User user;
    public Transform orderBookList; 
    public GameObject OrderBookListPrefab;
    
  
    public GameObject background;
    public TextMeshProUGUI orderIDText;
    public TextMeshProUGUI topayName; 
    public TextMeshProUGUI status;
    
    void Start()
    {
        managerOrder = FindObjectOfType<Manager_order>();
        user = DataManager.user;
        if (managerOrder == null)
        {
            Debug.LogError("Manager_order ไม่พบในฉาก");
        }
        if (user == null)
        {
            Debug.LogError("User not found in DataManager.");
        }
        
        var contentSizeFitter = Orderlist.gameObject.AddComponent<ContentSizeFitter>();
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        UpdateCostDisplay();
    }

    public void LoadOrder()
    {
        if (Orderlist == null)
        {
            Debug.LogError("Orderlist ไม่ได้ตั้งค่าใน Inspector");
            return;
        }


        while (Orderlist.childCount > 0) {
            DestroyImmediate(Orderlist.GetChild(0).gameObject);
        }
       
        int orderCount = 0;
        
        foreach (Order order in DataManager.orders.Values)
        {
            if (order.UserID != DataManager.user.UserID)
            {
                continue;
            }

            GameObject clone = Instantiate(OrderPrefab, Orderlist);
            clone.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 100);

            orderIDText = clone.transform.Find("orderIDText").GetComponent<TextMeshProUGUI>();
            orderIDText.text = $"Order ID: {order.OrdarID}";

           
            topayName = clone.transform.Find("topayName").GetComponent<TextMeshProUGUI>();
            topayName.text = $"ที่อยู่: {order.OrderDetail}"; 

            // Set order status from DataManager
            status = clone.transform.Find("status").GetComponent<TextMeshProUGUI>();
            status.text = order.Status;

            orderCount++;
        }
        if (orderCount > 3)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(Orderlist.GetComponent<RectTransform>());
        }
    }

    public void ShowOrderDetail(Order order)
{
    Debug.Log("ถูกปิดการแสดงผลรายละเอียดของการสั่งซื้อ");
}


    private void UpdateCostDisplay()
    {
        if (managerOrder == null)
        {
            Debug.LogError("Manager_order ไม่พบในฉาก");
            return;
        }

        
    }
}
