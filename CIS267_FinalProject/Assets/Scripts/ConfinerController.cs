using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConfinerController : MonoBehaviour
{
    public TilemapCollider2D tilemapCollider2D;

    Bounds mapBounds;
    PolygonCollider2D polygonCollider2D;
    // Start is called before the first frame update
    void Start()
    {

        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        mapBounds = tilemapCollider2D.bounds;

        Debug.Log("Bounds X:" + mapBounds.extents.x);

        Vector2[] colliderPoints;

        colliderPoints = polygonCollider2D.points;

        colliderPoints[0] = new Vector2(mapBounds.center.x - mapBounds.extents.x + 1, mapBounds.center.y + mapBounds.extents.y - 1);
        colliderPoints[1] = new Vector2(mapBounds.center.x + mapBounds.extents.x - 1, mapBounds.center.y + mapBounds.extents.y - 1);
        colliderPoints[2] = new Vector2(mapBounds.center.x + mapBounds.extents.x - 1, mapBounds.center.y - mapBounds.extents.y + 1);
        colliderPoints[3] = new Vector2(mapBounds.center.x - mapBounds.extents.x + 1, mapBounds.center.y - mapBounds.extents.y + 1);
        polygonCollider2D.points = colliderPoints;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
