using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : MonoBehaviour
{
    Transform t;
    PolygonCollider2D polygonCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<Transform>();
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();

        Vector2[] colliderPoints;

        colliderPoints = polygonCollider2D.points;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("RandomRoamingDirection");
    }

    IEnumerator RandomRoamingDirection()
    {
        int randomNumber = Random.Range(1, 9);



        yield return new WaitForSeconds(5f);
    }
}
