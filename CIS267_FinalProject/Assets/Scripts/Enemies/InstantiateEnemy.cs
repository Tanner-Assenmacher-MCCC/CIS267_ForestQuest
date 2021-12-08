using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4f);

        Instantiate(enemy, gameObject.transform);
    }
}
