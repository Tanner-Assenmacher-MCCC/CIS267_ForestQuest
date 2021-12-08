using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    public GameObject enemy;
    bool spawned = true;
    GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        clone = Instantiate(enemy, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemyScript = clone.GetComponent<Enemy>();
        if (enemyScript.die)
        {
            enemyScript.die = false;
            Invoke("Respawn", 5f);
        }
    }

    public void Respawn()
    {
        clone = Instantiate(enemy, gameObject.transform);
        spawned = true;

        Destroy(clone);
    }
}
