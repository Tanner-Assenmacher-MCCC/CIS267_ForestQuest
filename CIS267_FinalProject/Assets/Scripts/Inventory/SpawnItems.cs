using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public ScriptableWeapon heroic;
    public ScriptableWeapon dagger;
    public ScriptableWeapon knife;

    public float drag;
    public float force;

    private void MoveItem(GameObject gameObject)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
        gameObject.GetComponent<Rigidbody2D>().drag = drag;
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

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    FindObjectOfType<Player>().DropItem(0);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    FindObjectOfType<Player>().DropItem(1);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    FindObjectOfType<Player>().DropItem(3);
        //}

        
    }
}
