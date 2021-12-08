using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour
{
    // public AudioMixer mixer;
    Player playerScript;
    Animator animator;
    Transform player;
    public int sceneIndex;
    public Animator musicTransition;
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<Player>().GetComponent<Player>();
        animator = FindObjectOfType<Player>().GetComponent<Animator>();
        Debug.Log("Last Level Index: " + PlayerPrefs.GetInt("lastLevel"));
        Debug.Log("Current Scene Index: " + SceneManager.GetActiveScene().buildIndex);
        player = FindObjectOfType<Player>().transform;
        if (PlayerPrefs.GetInt("lastLevel") == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.position = new Vector3(-7.53f, -8.82f, 0f);
            animator.SetFloat("lastMoveVertical", 1f);
        }

        else if (PlayerPrefs.GetInt("lastLevel") == 2 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            player.position = new Vector3(-28.47f, 119.3f, 0f);
        }

        else if (PlayerPrefs.GetInt("lastLevel") == 1 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            player.position = new Vector3(-61.7f, 54.4f, 0f);
            animator.SetFloat("lastMoveVertical", -1f);
        }

        else if (PlayerPrefs.GetInt("lastLevel") == 3 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            player.position = new Vector3(362.48f, 145.36f, 0f);
            animator.SetFloat("lastMoveVertical", 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimeToTransition()
    {
        transition.SetTrigger("Start");
        musicTransition.SetTrigger("Start");
        playerScript.enabled = false;

        yield return new WaitForSeconds(transitionTime);
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameManager"));
        //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Inventory"));
        playerScript.enabled = true;
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

    // public void SetLevel(float sliderValue)
    // {
    //     mixer.SetFloat("AudioVol", -80.00f);
    // }
}
