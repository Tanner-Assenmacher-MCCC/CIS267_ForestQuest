using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    // public Animator musicTransition;
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
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
            StartCoroutine("TimeToTransition");
        }
    }
}
