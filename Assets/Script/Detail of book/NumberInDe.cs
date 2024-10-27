using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using static Unity.Collections.AllocatorManager;

public class NumberInDe : MonoBehaviour
{
    public Book bo;
    public TextMeshProUGUI numbertext;
    int count = 0;
    int value = 0;
  
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
            print(count);
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
