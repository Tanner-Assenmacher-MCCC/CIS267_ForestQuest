using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    public Slider slider;
    //public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider = FindObjectOfType<Slider>();
    }

    private void Update()
    {

    }

    public void SetHealthToMax()
    {
        slider.value = slider.maxValue;
        //fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int xp)
    {
        slider.value = xp;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
