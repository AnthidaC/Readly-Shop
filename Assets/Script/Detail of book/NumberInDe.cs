using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;


public class NumberInDe : MonoBehaviour
{
    public  UILoaderDetail bo;
    public TextMeshProUGUI numbertext;
    int count = 1;
    int value = 1;

    public void Start()
    {
        bo = FindFirstObjectByType<UILoaderDetail>();

    }
    public int ButtonPressIncrease
    {
        get { return count; }
        set
        {
            print(bo.Orderbook.Stock);
            if (count < bo.Orderbook.Stock)
            {

                count++;
                numbertext.text = count + "";
            }
            
        }
    }
    
    public int ButtonPressDecrease
    {
        get { return count; }
        set
        {
            if (count > 1)
            {
                count--;
                numbertext.text = count + "";
            }
            print(count);
        }
    }



}
