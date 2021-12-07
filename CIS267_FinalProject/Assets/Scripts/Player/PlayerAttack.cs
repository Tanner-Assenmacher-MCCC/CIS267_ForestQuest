using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Animator animator;
    public AudioSource slash;
    public bool attacking = false;
    private float attackTime;
    private float animationLength;
    public float attackCooldown;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        animationLength = 0.5f;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attacking && !InventoryUI.isActive && FindObjectOfType<WeaponHolster>().hasWeapon)
        {
            animator.SetTrigger("Attacking");
            animator.SetBool("Attack", false);
            attacking = true;
            FindObjectOfType<AudioManager>().Play("Slash");
            Attack();
        }

        if (attacking)
        {
            attackTime += Time.deltaTime;
            rb2d.velocity = Vector2.zero;

            if (attackTime >= animationLength)
            {
                attacking = false;
            }

            if (attackTime >= attackCooldown)
            {
                attackTime = 0;
                attacking = false;
            }
        }
    }

    void Attack()
    {
       Collider2D[] colliders =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

       foreach (Collider2D collider in colliders)
       {
            if (collider.CompareTag("Enemy"))
            {
                WeaponHolster weaponHolster = GetComponentInChildren<WeaponHolster>();
                if (weaponHolster.hasWeapon)
                {
                    collider.gameObject.GetComponent<Enemy>().TakeDamage(weaponHolster.scriptableWeapon.damage);
                }
                
            }
       }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
