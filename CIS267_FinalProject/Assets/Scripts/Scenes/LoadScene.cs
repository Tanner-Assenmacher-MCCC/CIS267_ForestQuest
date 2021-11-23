using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DontDestroyOnLoad(GameObject.FindObjectOfType<Player>());
            DontDestroyOnLoad(GameObject.FindObjectOfType<ConfinerController>());
            DontDestroyOnLoad(GameObject.FindObjectOfType<Camera>());
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("CinemachineCamera"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameManager"));
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Inventory"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody2D>().transform.position = new Vector2(-7.3f, -10.4f);
        }
    }
}
