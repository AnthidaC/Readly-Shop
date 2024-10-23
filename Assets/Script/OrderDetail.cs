using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderDetail : MonoBehaviour
{
    public Order order;
    public TMP_Text orderID;
    public TMP_Text userID;
    public TMP_Dropdown status;

    public void Show()
    {
     
        orderID.text=order.OrdarID.ToString();
        userID.text=order.UserID.ToString();
        print(((orderStatus)order.status).ToString()+ order.OrdarID.ToString());
        status.value = (int)order.status;
    }
    public void detail()
    {
        PageManager pM = FindFirstObjectByType<PageManager>();
        pM.ShowOrderDetail(order);

    }




}
