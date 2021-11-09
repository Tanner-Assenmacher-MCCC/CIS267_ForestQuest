using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public ScriptableWeapon heroic;
    public ScriptableWeapon dagger;
    public ScriptableWeapon knife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(heroic.prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(dagger.prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(knife.prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(Inventory.instance.items[0].prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
            Inventory.instance.Remove(Inventory.instance.items[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(Inventory.instance.items[1].prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
            Inventory.instance.Remove(Inventory.instance.items[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(Inventory.instance.items[2].prefab, transform.position + new Vector3(0, 4, 0), transform.rotation);
            Inventory.instance.Remove(Inventory.instance.items[2]);
        }
    }
}
