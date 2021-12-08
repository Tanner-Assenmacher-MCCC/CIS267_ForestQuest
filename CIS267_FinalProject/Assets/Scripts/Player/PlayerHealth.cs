using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public static int playerHealth = 100;
    public int maxHealth = 100;
    private float timer;
    private HealthBar healthBar;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        healthBar = FindObjectOfType<HealthBar>();
        //healthBar.SetHealth(playerHealth);
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
        if (Input.GetKeyDown(KeyCode.K))
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
            StartCoroutine(GameOver(false));
        }
    }

    public IEnumerator GameOver(bool winGame)
    {
        if (winGame)
        {//WINNER
            Debug.Log("Game Win");
        }
        else
        {//LOSER

            animator.SetTrigger("Start");
            Debug.Log("Game Lose");
            yield return new WaitForSeconds(3f);
            animator.SetTrigger("End");
            playerHealth = maxHealth;
            healthBar.SetHealth(playerHealth);

            if (PlayerPrefs.GetInt("lastLevel") == 0 && SceneManager.GetActiveScene().buildIndex == 1)
            {
                playerTransform.position = new Vector3(-7.53f, -8.82f, 0f);
                animator.SetFloat("lastMoveVertical", 1f);
            }

            else if (PlayerPrefs.GetInt("lastLevel") == 2 && SceneManager.GetActiveScene().buildIndex == 1)
            {
                playerTransform.position = new Vector3(-28.47f, 119.3f, 0f);
            }

            else if (PlayerPrefs.GetInt("lastLevel") == 1 && SceneManager.GetActiveScene().buildIndex == 0)
            {
                playerTransform.position = new Vector3(-61.7f, 54.4f, 0f);
                animator.SetFloat("lastMoveVertical", -1f);
            }

            else if (PlayerPrefs.GetInt("lastLevel") == 1 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                playerTransform.position = new Vector3(-21.31f, 1.84001f, 0f);
                animator.SetFloat("lastMoveVertical", -1f);
            }

            else if (PlayerPrefs.GetInt("lastLevel") == 3 && SceneManager.GetActiveScene().buildIndex == 2)
            {
                playerTransform.position = new Vector3(362.48f, 145.36f, 0f);
                animator.SetFloat("lastMoveVertical", 1f);
            }
        }
    }
}
