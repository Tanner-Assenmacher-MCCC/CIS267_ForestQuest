using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class we_warp : MonoBehaviour
{
    public bool down;

    public GameObject target;

    public GameObject fade;

    private CircleCollider2D myCollider;

    private static float exitAmount = 1.5f;

    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CircleCollider2D>();
        fade.GetComponent<SpriteRenderer>().enabled = false;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fadeScreen(collision.gameObject);
        }
    }

    private void fadeScreen(GameObject player)
    {
        fade.GetComponent<SpriteRenderer>().enabled = true;

        warpPlayer(player);
    }

    private void warpPlayer(GameObject player)
    {
        if(target.GetComponent<we_warp>().exitDown())
        {
            player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - exitAmount, player.transform.position.z);
            playerScript.SetVerticalDirection(-1);
        }
        else
        {
            player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + exitAmount, player.transform.position.z);
            playerScript.SetVerticalDirection(1);
        }


    }

    private void unfadeScreen()
    {
        fade.GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool exitDown()
    {
        return down;
    }
}
