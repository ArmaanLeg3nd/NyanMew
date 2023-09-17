using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartvalue : MonoBehaviour
{
    public int hvalue = 0;
    public Slider slider;
    private bool reducing;
    public void inc_hvalue()
    {
        hvalue += 1;
    }

    private void Update()
    {
        slider.value = hvalue;
        if (!reducing)
        {
            reducing = true;
            InvokeRepeating("ReduceSliderValue", 0.5f, 0.5f);
        }
    }

    private void ReduceSliderValue()
    {
        if (hvalue > 0)
        {
            hvalue--;
            slider.value = hvalue;
        }
        else
        {
            reducing = false;
            CancelInvoke("ReduceSliderValue");
        }
    }
}
