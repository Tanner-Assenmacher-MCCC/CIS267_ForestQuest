using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPbar : MonoBehaviour
{
    private Slider slider;
    //public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {

    }

    public void SetXPToMax()
    {
        slider.value = slider.maxValue;
        //fill.color = gradient.Evaluate(1f);
    }
    public void SetXP(int xp)
    {
        slider.value = xp;
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
