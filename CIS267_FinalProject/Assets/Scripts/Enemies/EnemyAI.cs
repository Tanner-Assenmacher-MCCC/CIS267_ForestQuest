using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    [Header("Speed")]
    [Range(1f, 6f)]
    [SerializeField] private float speed;
    [Header("Follow Range")]
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [Header("Attacking")]
    [Range(0f, 5f)]
    [SerializeField] private float attackRate;
    float nextWaypointDistance = 3f;
    private float time;
    private bool hasFollowed;
    private bool attackedOnce;
    Path path;
    Seeker seeker;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    // Start is called before the first frame update
    void Start()
    {
        time = attackRate;
        hasFollowed = false;
        attackedOnce = false;
        animator = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
        seeker.GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(gameObject.transform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)gameObject.transform.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;


        float distance = Vector2.Distance(gameObject.transform.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // if (Vector3.Distance(target.position, transform.position) <= maxRange)
        // {
        //     if (Vector3.Distance(target.position, transform.position) <= minRange)
        //     {
        //         animator.SetBool("isMoving", false);
        //         AttackPlayer();
        //     }
        //     else
        //     {
        //         attackedOnce = false;
        //         hasFollowed = true;
        //         FollowPlayer();
        //     }
        // }

        // else if (Vector3.Distance(target.position, transform.position) > maxRange && hasFollowed)
        // {
        //     GoHome();
        // }
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
        time += Time.deltaTime;
        animator.SetBool("Attack", false);

        if (time >= attackRate || !attackedOnce)
        {
            animator.SetBool("Attack", true);
            time = 0;
            attackedOnce = true;
        }
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
