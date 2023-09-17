using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private int hvalue;
    private bool reducing;

    private void Start()
    {
        slider.value = hvalue;
    }

    public void UpdateHValue(float value)
    {
        hvalue = Mathf.RoundToInt(value);
        slider.value = hvalue;

        if (hvalue >= slider.maxValue && !reducing)
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
