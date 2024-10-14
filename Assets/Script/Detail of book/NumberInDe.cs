using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class NumberInDe : MonoBehaviour
{
    public TextMeshProUGUI numbertext;
    int count = 0;

    public void ButtomPressIncrease()
    {
        count++;
        numbertext.text = count + "";
    }
    
    public void ButtomPressDecrease()
    {
        if (count > 0 )
        {
            count--;
            numbertext.text = count + "";
        }
        
    }


}
