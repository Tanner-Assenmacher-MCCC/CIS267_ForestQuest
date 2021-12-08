using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    TextMeshProUGUI healthDisplay;
    PlayerHealth playerHealthScript;
    private Slider slider;
    //public Gradient gradient;
    public Image fill;

    private void Start()
    {
        playerHealthScript = this.GetComponent<PlayerHealth>();
        healthDisplay = this.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        slider = GetComponent<Slider>();
        SetHealth(PlayerHealth.playerHealth);
        slider.maxValue = PlayerHealth.playerHealth;
    }

    private void Update()
    {

    }

    public void SetHealthToMax()
    {
        slider.value = slider.maxValue;
        //fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        healthDisplay.text = health.ToString();
        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
