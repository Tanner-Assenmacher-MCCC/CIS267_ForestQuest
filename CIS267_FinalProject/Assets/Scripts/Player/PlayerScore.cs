using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 0;
    public int levelNumber = 1;
    public int maxScore = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int val)
    {
        playerScore += val;
        if (playerScore >= maxScore)
        {
            int tmpScore = playerScore - 100;
            levelNumber++;
            playerScore = tmpScore;
        }
    }

    public int getScore()
    {
        return playerScore;
    }

    public void addLevel()
    {
        levelNumber++;
    }

    public int getLevel()
    {
        return levelNumber;
    }
}
