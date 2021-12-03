using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    public int damage = 5;
    public int xp = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0) SetHealth(this.health -= amount);
        Debug.Log("Enemy Health: " + health);
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int h)
    {
        health = h;
    }

    public void Die()
    {
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        playerScore.addScore(this.xp);
        Destroy(this.gameObject);
    }
}
