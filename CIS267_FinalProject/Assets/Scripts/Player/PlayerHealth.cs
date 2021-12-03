using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private int maxHealth = 100;
    private float timer;
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > 1f)
        //{//after second, subtracts one from health
        //    addHealth(-1);
        //    timer = 0;
        //}
        //if (timer > 30f)
        //{
        //    timer = 0;
        //}
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerHealth -= 10;
            healthBar.SetHealth(playerHealth);
        }
    }

    public int getHealth()
    {
        return playerHealth;
    }

    public void addHealth(int val)
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

    public void subtractHealth(int val)
    {
        playerHealth -= val;
        healthBar.SetHealth(playerHealth);

        if ((playerHealth <= 0))
        {
            Debug.Log("You Lost");
            GameOver(false);
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
