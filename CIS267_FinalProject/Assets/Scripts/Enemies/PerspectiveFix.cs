using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveFix : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y > player.transform.position.y)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
        }
    }
}
