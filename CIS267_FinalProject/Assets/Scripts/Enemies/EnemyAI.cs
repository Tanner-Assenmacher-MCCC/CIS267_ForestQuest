using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public GameObject projectile;
    AudioManager audioManager;
    Vector2[] colliderPoints;
    Transform t;
    PolygonCollider2D polygonCollider2D;
    private Rigidbody2D rb2d;
    private Animator animator;
    private Transform target;
    [Header("Speed")]
    [Range(1f, 2000f)]
    [SerializeField] private float speed;
    [Header("Follow Range")]
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [Header("Attacking")]
    [Range(0f, 5f)]
    [SerializeField] private float attackRate;
    float nextWaypointDistance = 1f;
    private float time;
    private bool hasFollowed = false;
    private bool attackedOnce;
    Path path;
    Seeker seeker;
    int blockingLayer;
    int currentWaypoint = 0;
    bool hitEndOfRoamingPath = false;
    bool reachedEndOfPath = false;
    public int offset;
    public float attackDelay = 0f;
    public bool rangedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        t = gameObject.GetComponent<Transform>();
        time = attackRate;
        hasFollowed = false;
        attackedOnce = false;
        target = FindObjectOfType<Player>().transform;
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        blockingLayer = LayerMask.NameToLayer("Blocking");

        colliderPoints = polygonCollider2D.points;
        polygonCollider2D.offset = new Vector2(-t.parent.position.x, -t.parent.position.y);

        colliderPoints[0] = new Vector2(t.position.x + offset, t.position.y - offset);
        colliderPoints[1] = new Vector2(t.position.x + offset, t.position.y);
        colliderPoints[2] = new Vector2(t.position.x + offset, t.position.y + offset);
        colliderPoints[3] = new Vector2(t.position.x, t.position.y + offset);
        colliderPoints[4] = new Vector2(t.position.x - offset, t.position.y + offset);
        colliderPoints[5] = new Vector2(t.position.x - offset, t.position.y);
        colliderPoints[6] = new Vector2(t.position.x - offset, t.position.y - offset);
        colliderPoints[7] = new Vector2(t.position.x, t.position.y - offset);

        polygonCollider2D.points = colliderPoints;

        InvokeRepeating("UpdatePath", 0f, .5f);
        InvokeRepeating("UpdateRoamingPath", 0f, 5f);
    }

    void UpdatePath()
    {
        float distanceX = Mathf.Abs((Mathf.Abs(target.position.x) - Mathf.Abs(rb2d.position.x)));
        float distanceY = Mathf.Abs((Mathf.Abs(target.position.y) - Mathf.Abs(rb2d.position.y)));

        // Debug.Log("Animation Float Value X: " + animator.GetFloat("moveX"));
        // Debug.Log("Animation Float Value Y: " + animator.GetFloat("moveY"));
        // RaycastHit2D raycastUp = Physics2D.Raycast(transform.position, Vector2.up, 5f, blockingLayer);
        // RaycastHit2D raycastDown = Physics2D.Raycast(transform.position, -Vector2.up, 5f, blockingLayer);
        // RaycastHit2D raycastRight = Physics2D.Raycast(transform.position, Vector2.right, 5f, blockingLayer);
        // RaycastHit2D raycastLeft = Physics2D.Raycast(transform.position, -Vector2.right, 5f, blockingLayer);
        // if (seeker.IsDone() && Vector3.Distance(target.position, transform.position) <= maxRange && (hasFollowed || hitEndOfRoamingPath) && raycast.transform.gameObject.layer == blockingLayer)
        // {
        //     seeker.StartPath(rb2d.position, transform.parent.position, OnPathComplete);
        // }

        if (seeker.IsDone() && Vector3.Distance(target.position, transform.position) <= maxRange && (hasFollowed || hitEndOfRoamingPath) && !Physics2D.Raycast(transform.position, new Vector2(0f, -1f), 5f, blockingLayer))
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplete);
        }

        if (seeker.IsDone() && Vector3.Distance(target.position, transform.position) <= maxRange && (hasFollowed || hitEndOfRoamingPath) && Physics2D.Raycast(transform.position, new Vector2(0f, -1f), 5f, blockingLayer))
        {
            seeker.StartPath(rb2d.position, transform.parent.position, OnPathComplete);
        }

        else if (seeker.IsDone() && Vector3.Distance(target.position, transform.position) > maxRange && hasFollowed)
        {
            seeker.StartPath(rb2d.position, transform.parent.position, OnPathComplete);
        }
    }

    void UpdateRoamingPath()
    {
        if (Vector3.Distance(target.position, transform.position) > maxRange && !hasFollowed)
        {
            int rand;
            rand = Random.Range(0, 8);

            seeker.StartPath(rb2d.position, polygonCollider2D.points[rand], OnPathComplete);
        }
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

        if (Vector3.Distance(target.position, transform.position) <= maxRange)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;

            Vector2 force = direction * speed * Time.deltaTime * 100;

            float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

            if (Vector3.Distance(target.position, transform.position) <= minRange && !rangedEnemy)
            {
                animator.SetBool("isMoving", false);
                Attack();
            }
            else if (Vector3.Distance(target.position, transform.position) <= minRange && rangedEnemy)
            {
                animator.SetBool("isMoving", false);
                ShootProjectiles();
            }
            else
            {
                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }
                attackedOnce = false;
                hasFollowed = true;
                animator.SetBool("Attack", false);
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", (target.position.x - transform.position.x));
                animator.SetFloat("moveY", (target.position.y - transform.position.y));
                rb2d.AddForce(force);
            }
        }

        if (Vector3.Distance(target.position, transform.position) > maxRange && hasFollowed)
        {
            GoHome();
        }

        else if (Vector3.Distance(target.position, transform.position) > maxRange && !hasFollowed)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;

            Vector2 force = direction * speed * Time.deltaTime * 100;

            float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            rb2d.AddForce(force);

            if (currentWaypoint >= path.vectorPath.Count)
            {
                animator.SetBool("isMoving", false);
                hitEndOfRoamingPath = true;
            }
            else
            {
                animator.SetBool("Attack", false);
                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", (path.vectorPath[currentWaypoint].x - transform.position.x));
                animator.SetFloat("moveY", (path.vectorPath[currentWaypoint].y - transform.position.y));
            }
        }
    }

    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }

    private void AttackPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) < minRange + 1f)
        {
            Player player = FindObjectOfType<Player>();
            Enemy enemy = GetComponent<Enemy>();
            player.GetComponent<PlayerHealth>().subtractHealth(enemy.damage);
            player.Flash();
            audioManager.GetComponent<AudioSource>().pitch = Random.Range(1f, 1.75f);
            audioManager.PlayOneShot("PlayerHit");
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2((animator.GetFloat("moveX") / Mathf.Abs(animator.GetFloat("moveX"))) * 1000, (animator.GetFloat("moveY") / Mathf.Abs(animator.GetFloat("moveY"))) * 1000));
        }
    }

    private void RangedAttackPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) < minRange + 1f)
        {
            Player player = FindObjectOfType<Player>();
            Enemy enemy = GetComponent<Enemy>();
            GameObject clone = Instantiate(projectile, this.transform);
            Projectiles proj = clone.GetComponent<Projectiles>();

            Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, dir);
            clone.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360f);

            clone.GetComponent<Rigidbody2D>().velocity = dir.normalized * proj.speed;
        }
    }

    public void Attack()
    {
        time += Time.deltaTime;
        animator.SetBool("Attack", false);

        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));

        if (time >= attackRate || !attackedOnce)
        {
            Debug.Log("IN ATTACKING!");
            animator.SetBool("Attack", true);
            Invoke(nameof(AttackPlayer), attackDelay);
            time = 0;
            attackedOnce = true;
        }
    }

    public void ShootProjectiles()
    {
        time += Time.deltaTime;
        animator.SetBool("Attack", false);

        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));

        if (time >= attackRate || !attackedOnce)
        {
            Debug.Log("IN ATTACKING!");
            animator.SetBool("Attack", true);
            Invoke(nameof(RangedAttackPlayer), attackDelay);
            time = 0;
            attackedOnce = true;
        }
    }

    public void GoHome()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime * 100;

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        rb2d.AddForce(force);

        animator.SetBool("Attack", false);
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (transform.parent.position.x - transform.position.x));
        animator.SetFloat("moveY", (transform.parent.position.y - transform.position.y));

        if (Vector3.Distance(transform.position, transform.parent.position) < 1f)
        {
            animator.SetBool("isMoving", false);
            hasFollowed = false;
        }
    }
}
