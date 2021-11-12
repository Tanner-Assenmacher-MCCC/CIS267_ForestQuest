using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Animator animator;
    Vector3 moveDelta;
    RaycastHit2D hit;
    public int speed;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Press shift to Sprint
        if (Input.GetKey("left shift"))
        {
            rb2d.velocity = new Vector2(x, y) * speed * 1.5f * Time.fixedDeltaTime;
            animator.speed = 1.5f;
        }

        else
        {
            // Move player at normal speed
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
            animator.speed = 1f;
        }

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // /* ANIMATION STUFF

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetFloat("lastMoveHorizontal", moveDelta.x);
            animator.SetFloat("lastMoveVertical", moveDelta.y);
        }

        animator.SetFloat("Vertical", moveDelta.y);
        animator.SetFloat("Horizontal", moveDelta.x);

        //  END */
    }

    public void DropItem(int i)
    {
        float drag = 4.5f;
        float force = 100f;
        float itemDropOffset = 1.5f;
        float horizontal = animator.GetFloat("lastMoveHorizontal");
        float vertical = animator.GetFloat("lastMoveVertical");
        if (horizontal == 0f && vertical == 1f) // up
        {
            GameObject instance = Instantiate(Inventory.instance.items[i].prefab, transform.position + new Vector3(0f, itemDropOffset, 0f), transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force));
            instance.GetComponent<Rigidbody2D>().drag = drag;
            Inventory.instance.Remove(Inventory.instance.items[i]);
        }
        else if (horizontal == 1f && vertical == 0f) // right
        {
            GameObject instance = Instantiate(Inventory.instance.items[i].prefab, transform.position + new Vector3(itemDropOffset, 0f, 0f), transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0f));
            instance.GetComponent<Rigidbody2D>().drag = drag;
            Inventory.instance.Remove(Inventory.instance.items[i]);
        }
        else if (horizontal == 0f && vertical == -1f) // down
        {
            GameObject instance = Instantiate(Inventory.instance.items[i].prefab, transform.position + new Vector3(0f, -itemDropOffset, 0f), transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force));
            instance.GetComponent<Rigidbody2D>().drag = drag;
            Inventory.instance.Remove(Inventory.instance.items[i]);
        }
        else // left
        {
            GameObject instance = Instantiate(Inventory.instance.items[i].prefab, transform.position + new Vector3(-itemDropOffset, 0f, 0f), transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0f));
            instance.GetComponent<Rigidbody2D>().drag = drag;
            Inventory.instance.Remove(Inventory.instance.items[i]);
        }
    }
}
