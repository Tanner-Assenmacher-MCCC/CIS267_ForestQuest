using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private int maxHealth = 1000;
    private float timer;
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        playerHealth = 1000;
        healthBar.SetHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {//after second, subtracts one from health
            setHealth(-1);
            timer = 0;
        }
        if (timer > 30f)
        {
            timer = 0;
        }
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public void setHealth(int val)
    {
        if ((playerHealth + val) >= maxHealth)
        {
            playerHealth = maxHealth;
            healthBar.SetHealth(playerHealth);
        }
        else if ((playerHealth + val) <= 0)
        { 
            Debug.Log("You Lost");
            GameOver(false);
        }
        else
        {
            playerHealth += val;
            healthBar.SetHealth(playerHealth);
        }
        
    }

    public void GameOver(bool winGame)
    {
        Time.timeScale = 0;
        if (winGame)
        {//WINNER
            Debug.Log("Game Win");
        }
        else
        {//LOSER
            Debug.Log("Game Lose");
        }
    }
}
