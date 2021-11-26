using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    private int maxHealth = 100000000;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 80;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {//after second, subtracts one from health
            setScore(-1);
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

    public void setScore(int val)
    {
        if ((playerHealth + val) >= maxHealth)
        {
            playerHealth = maxHealth;
        }
        else if ((playerHealth + val) <= 0)
        { 
            Debug.Log("You Lost");
            GameOver(false);
        }
        else
        {
            playerHealth += val;
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
