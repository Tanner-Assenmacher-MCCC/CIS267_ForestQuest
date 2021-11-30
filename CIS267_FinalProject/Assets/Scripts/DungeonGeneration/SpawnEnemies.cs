using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private int rand;
    public GameObject[] SpawnList;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, SpawnList.Length);
        Instantiate(SpawnList[rand], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
