using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Move player
        rb2d.velocity = new Vector2(x * speed, y * speed);


        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // /* ANIMATION STUFF
        animator.SetFloat("Horizontal", moveDelta.x);
        animator.SetFloat("Vertical", moveDelta.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveHorizontal", moveDelta.x);
            animator.SetFloat("lastMoveVertical", moveDelta.y);
        }

        //  END */
    }
}
