using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public int levelIndex;
    public float transitionTime = 3f;
    public Animator transition;
    public Animator soundTransition;
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(levelIndex));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        soundTransition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load the scene
        SceneManager.LoadScene(levelIndex);
    }
}
