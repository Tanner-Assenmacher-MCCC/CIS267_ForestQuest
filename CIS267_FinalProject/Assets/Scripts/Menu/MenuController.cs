using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Transition Speed
    public float transitionSpeed;

    //Buttons
    public GameObject ButtonPlayGame;
    public GameObject ButtonLoadGame;
    public GameObject ButtonSettings;
    public GameObject ButtonQuit;
    public GameObject ButtonVolume;


    //Camera Travel Points
    public GameObject CameraPointMain;
    public GameObject CameraPointSettings;

    private Rigidbody2D rigidBody2D;

    //Menu States
    private int state = 0;

    private bool movingToSettings;
    private bool movingToMain;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        state = 0;
        updateButtonColors();

        movingToSettings = false;
        movingToMain = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown(KeyCode.W);
        bool down = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        bool right = Input.GetKeyDown(KeyCode.D);
        bool enter = Input.GetKeyDown(KeyCode.Return);

        if (state == 0)
        {
            //Hover Play Game
            if (enter && !movingToMain)
            {
                //Play Game
                SceneManager.LoadScene(0);
            }
            else if (down)
            {
                //Move to load
                state = 1;
                updateButtonColors();
            }

        }
        else if (state == 1)
        {
            //Hover Load Game
            if (enter && !movingToMain)
            {
                //Load Game

            }
            else if (up)
            {
                //move to play
                state = 0;
                updateButtonColors();
            }
            else if (down)
            {
                //move to settings
                state = 2;
                updateButtonColors();
            }
        }
        else if (state == 2)
        {
            //Hover Settings
            if (enter && !movingToMain)
            {
                //Scroll to settings

                movingToSettings = true;

                state = 4;
                updateButtonColors();
            }
            else if (up)
            {
                //move to load
                state = 1;
                updateButtonColors();
            }
            else if (down)
            {
                //move to quit
                state = 3;
                updateButtonColors();
            }
        }
        else if (state == 3)
        {
            //Hover Quit
            if (enter && !movingToMain)
            {
                //Quit Game
                Application.Quit();
            }
            else if (up)
            {
                //move to settings
                state = 2;
                updateButtonColors();
            }
        }
        else if (state == 4)
        {
            //Hover Volume
            if (left)
            {
                //Volume Down
            }
            else if (right)
            {
                //Volume Up
            }
            else if (!movingToSettings && (up || enter))
            {
                //Back to main
                movingToMain = true;

                state = 2;
                updateButtonColors();
            }
        }

        if (movingToMain)
        {
            if (transform.position.y < CameraPointMain.transform.position.y)
            {
                rigidBody2D.velocity = new Vector2(0, transitionSpeed);
                Debug.Log(rigidBody2D.velocity);
            }
            else
            {
                movingToMain = false;
                rigidBody2D.velocity = new Vector2(0, 0);
            }
        }
        else if (movingToSettings)
        {
            if (transform.position.y > CameraPointSettings.transform.position.y)
            {
                rigidBody2D.velocity = new Vector2(0, -transitionSpeed);
                Debug.Log(rigidBody2D.velocity);
            }
            else
            {
                movingToSettings = false;
                rigidBody2D.velocity = new Vector2(0, 0);
            }
        }
    }

    private void updateButtonColors()
    {
        if (state == 0) { ButtonPlayGame.GetComponent<SpriteRenderer>().color = Color.black; }
        else { ButtonPlayGame.GetComponent<SpriteRenderer>().color = Color.white; }
        if (state == 1) { ButtonLoadGame.GetComponent<SpriteRenderer>().color = Color.black; }
        else { ButtonLoadGame.GetComponent<SpriteRenderer>().color = Color.white; }
        if (state == 2) { ButtonSettings.GetComponent<SpriteRenderer>().color = Color.black; }
        else { ButtonSettings.GetComponent<SpriteRenderer>().color = Color.white; }
        if (state == 3) { ButtonQuit.GetComponent<SpriteRenderer>().color = Color.black; }
        else { ButtonQuit.GetComponent<SpriteRenderer>().color = Color.white; }
        if (state == 4) { ButtonVolume.GetComponent<SpriteRenderer>().color = Color.black; }
        else { ButtonVolume.GetComponent<SpriteRenderer>().color = Color.white; }
    }
}
