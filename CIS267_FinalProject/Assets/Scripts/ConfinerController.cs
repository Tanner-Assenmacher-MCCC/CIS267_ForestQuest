using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConfinerController : MonoBehaviour
{
    Transform t;
    public TilemapCollider2D tilemapCollider2D;
    Bounds mapBounds;
    PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<Transform>();
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        mapBounds = tilemapCollider2D.bounds;

        Debug.Log("Bounds X:" + mapBounds.extents.x);

        Vector2[] colliderPoints;

        colliderPoints = polygonCollider2D.points;

        colliderPoints[0] = new Vector2(mapBounds.center.x - mapBounds.extents.x + Mathf.Abs(t.position.x) + 1, mapBounds.center.y + mapBounds.extents.y - 1 + Mathf.Abs(t.position.y));
        colliderPoints[1] = new Vector2(mapBounds.center.x + mapBounds.extents.x - 1 - t.position.x, mapBounds.center.y + mapBounds.extents.y - 1 - t.position.y);
        colliderPoints[2] = new Vector2(mapBounds.center.x + mapBounds.extents.x - 1, mapBounds.center.y - mapBounds.extents.y + 1);
        colliderPoints[3] = new Vector2(mapBounds.center.x - mapBounds.extents.x + 1, mapBounds.center.y - mapBounds.extents.y + 1);
        polygonCollider2D.points = colliderPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
