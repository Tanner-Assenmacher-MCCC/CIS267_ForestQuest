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
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tempInfo, this.transform);
        enemyInfo = this.gameObject.transform.GetChild(0);
        textMesh = enemyInfo.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyInfo.position = new Vector2(this.transform.position.x + xDisp - 0.6f, this.transform.position.y + yDisp);

    }
}
