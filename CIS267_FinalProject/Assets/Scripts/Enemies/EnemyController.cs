using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    private bool hasFollowed;

    // Start is called before the first frame update
    void Start()
    {
        hasFollowed = false;
        animator = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange)
        {
            if (Vector3.Distance(target.position, transform.position) <= minRange)
            {
                animator.SetBool("isMoving", false);
                AttackPlayer();
            }
            else
            {
                hasFollowed = true;
                FollowPlayer();
            }
        }

        else if (Vector3.Distance(target.position, transform.position) > maxRange && hasFollowed)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        animator.SetBool("Attack", true);
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.parent.position, speed * Time.deltaTime);
        animator.SetBool("Attack", false);
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (transform.parent.position.x - transform.position.x));
        animator.SetFloat("moveY", (transform.parent.position.y - transform.position.y));

        if (transform.position == transform.parent.position)
        {
            animator.SetBool("isMoving", false);
            hasFollowed = false;
        }
    }
}
