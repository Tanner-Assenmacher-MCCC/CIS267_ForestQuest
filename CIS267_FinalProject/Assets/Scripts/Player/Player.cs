using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public GameObject inventory;
    public int itemInHolster;
    Rigidbody2D rb2d;
    public Animator animator;
    Vector3 moveDelta;
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
        if (!gameObject.GetComponent<PlayerAttack>().attacking && !inventory.activeInHierarchy)
        {
            // Press shift to Sprint
            if (Input.GetKey("left shift"))
            {
                Run();
            }

            else
            {
                Move();
            }

            animator.SetFloat("Vertical", moveDelta.y);
            animator.SetFloat("Horizontal", moveDelta.x);
        }

        else
        {
            rb2d.velocity = new Vector2(0f, 0f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Horizontal", 0f);
        }
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

    void Run()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Move player at normal speed
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime * 1.75f;
        animator.speed = 1.75f;

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // /* ANIMATION STUFF

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetFloat("lastMoveHorizontal", moveDelta.x);
            animator.SetFloat("lastMoveVertical", moveDelta.y);
        }
    }

    public void UseItem(Item item)
    {
        Debug.Log(item.GetType() == typeof(ScriptableWeapon));
        if (item.GetType() == typeof(ScriptableWeapon))
        {
            WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
            weaponHolster.scriptableWeapon = item as ScriptableWeapon;
            weaponHolster.GetComponent<SpriteRenderer>().sprite = item.sprite;
            weaponHolster.hasWeapon = true;
            if (!GameObject.Find("Inventory"))
            {
                weaponHolster.SelectedItemIcon.SetActive(true);
            }
        }
    }
}
