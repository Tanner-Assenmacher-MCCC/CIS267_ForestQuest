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
    bool waited = true;
    bool done = false;
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
        if (!gameObject.GetComponent<PlayerAttack>().currentlyAttacking)
        {
            // // Press shift to Sprint
            // if (Input.GetKey("left shift"))
            // {
            //     rb2d.velocity = new Vector2(x, y) * speed * 1.5f * Time.fixedDeltaTime;
            //     animator.speed = 1.5f;
            // }

            Move();
        }

        animator.SetFloat("Vertical", moveDelta.y);
        animator.SetFloat("Horizontal", moveDelta.x);
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Move player at normal speed
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
        animator.speed = 1f;

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // /* ANIMATION STUFF

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetFloat("lastMoveHorizontal", moveDelta.x);
            animator.SetFloat("lastMoveVertical", moveDelta.y);
        }
    }

    //public void UseItem(Item item)
    //{

    //}

    public void UseItem(ScriptableWeapon scriptableWeapon)
    {
        WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
        Debug.Log(weaponHolster);
        weaponHolster.scriptableWeapon = scriptableWeapon;
        weaponHolster.hasWeapon = true;
    }
}
