using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;


public class NumberInDe : MonoBehaviour
{
    public Book bo;
    public TextMeshProUGUI numbertext;
    int count = 1;
    int value = 1;
  
    public int ButtonPressIncrease
    {
        get { return count; }
        set
        {
            if (count < bo.Stock)
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
