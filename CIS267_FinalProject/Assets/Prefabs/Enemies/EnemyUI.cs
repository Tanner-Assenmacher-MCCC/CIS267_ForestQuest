using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    TextMeshProUGUI enemyLevel;
    TextMeshProUGUI enemyName;
    TextMeshProUGUI healthAmount;
    RectTransform enemyRect;
    public GameObject enemyInfo;
    GameObject clone;
    Slider healthBar;
    [Header("Position Offset")]
    [Range(-5f, 5f)]
    public float xDisp;
    [Range(-5f, 5f)]
    public float yDisp;
    [Header("Enemy Atributes")]
    public string name;

    [Range(1, 100)]
    public int level;
    int health;
    int initialHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Enemy>().GetHealth();
        initialHealth = health;
        clone = Instantiate(enemyInfo, this.transform);
        enemyRect = clone.GetComponent<RectTransform>();
        healthBar = clone.transform.GetChild(0).GetComponent<Slider>();
        healthBar.maxValue = initialHealth;
        healthAmount = clone.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        enemyName = clone.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        enemyLevel = clone.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRect.anchoredPosition = new Vector2(0f + xDisp, 0f + yDisp);
        healthBar.value = gameObject.GetComponent<Enemy>().GetHealth();
        healthAmount.text = gameObject.GetComponent<Enemy>().GetHealth().ToString();
        enemyName.text = name;
        enemyLevel.text = level.ToString();
    }
}
