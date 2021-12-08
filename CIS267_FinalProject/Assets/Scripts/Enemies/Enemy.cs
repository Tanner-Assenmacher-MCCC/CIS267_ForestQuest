using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] drops;
    [Range(1f, 100f)]
    public int[] dropRate;
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
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            this.health -= amount;
            Flash();
            if (health <= 0)
            {
                Die();
            }
        }
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

    private void ResetColor()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }

    public void Flash()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(255, 100, 100, 255);
        Invoke(nameof(ResetColor), 0.2f);
    }

    public void Die()
    {
        int dropRateTotal = 0;
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        playerScore.addScore(this.xp);
        foreach (GameObject drop in drops)
        {
            for (int i = 0; i < dropRate.Length; i++)
            {
                int randomDrop = Random.Range(0, 100);
                if (randomDrop >= 0 + dropRateTotal || randomDrop <= dropRate[i])
                {
                    Instantiate(drop, this.transform);
                }
                dropRateTotal += dropRate[i];
            }
        }
        Destroy(this.gameObject);
    }
}
