using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Transform player;
    public int sceneIndex;
    // public Animator musicTransition;
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Last Level Index: " + PlayerPrefs.GetInt("lastLevel"));
        Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
        player = FindObjectOfType<Player>().transform;
        if (PlayerPrefs.GetInt("lastLevel") == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.position = new Vector3(-7.53f, -8.82f, 0f);
        }

        else if (PlayerPrefs.GetInt("lastLevel") == 2 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.position = new Vector3(-28.47f, 119.3f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimeToTransition()
    {
        transition.SetTrigger("Start");
        // musicTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameManager"));
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Inventory"));
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
            StartCoroutine("TimeToTransition");
        }
    }
}
