using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    TextMesh textMesh;
    Transform enemyInfo;
    public GameObject tempInfo;
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
        health = gameObject.GetComponent<Enemy>().health;
        initialHealth = health;
        Instantiate(tempInfo, this.transform);
        enemyInfo = this.gameObject.transform.GetChild(0);
        textMesh = enemyInfo.GetComponent<TextMesh>();
        enemyInfo.GetComponent<MeshRenderer>().sortingOrder = 15;
    }

    // Update is called once per frame
    void Update()
    {
        enemyInfo.position = new Vector2(this.transform.position.x + xDisp, this.transform.position.y + yDisp);
        textMesh.text = "Health: " + health + "/" + initialHealth;

    }
}
