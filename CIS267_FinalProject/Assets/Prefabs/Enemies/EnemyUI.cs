using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    GameObject canvas;
    public GameObject info;
    public float xDisp;
    public float yDisp;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("EnemyUI");

        Instantiate(info, canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        info.transform.position = this.transform.position;
    }
}
