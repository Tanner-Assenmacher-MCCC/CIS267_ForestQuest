using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class we_warp : MonoBehaviour
{
    AudioSource musicToStop;
    public AudioSource musicToPlay;
    public Animator animatorMusic;
    AudioManager audioManager;
    public bool down;

    public GameObject target;

    public Animator fade;

    // public Animator musicFade;

    private CircleCollider2D myCollider;

    private bool warping;

    private static float exitAmount = 1.5f;

    private Animator animator;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        musicToStop = target.GetComponent<we_warp>().myAudioSource();
        audioManager = FindObjectOfType<AudioManager>();
        myCollider = GetComponent<CircleCollider2D>();
        animator = FindObjectOfType<Player>().GetComponent<Animator>();
        player = FindObjectOfType<Player>().gameObject;
        warping = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !warping)
        {
            StartCoroutine(fadeScreen(collision.gameObject));
            warping = true;
        }
    }

    private IEnumerator fadeScreen(GameObject player)
    {
        fade.speed = 3;
        fade.SetTrigger("Start");

        animatorMusic.speed = 2;

        animatorMusic.SetTrigger("Start");

        // musicFade.SetTrigger("Start");
        player.GetComponent<Player>().enabled = false;
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);

        yield return new WaitForSeconds(0.75f);

        musicToStop.Stop();

        player.GetComponent<Player>().enabled = true;

        musicToPlay.Play();
        musicToPlay.GetComponent<Animator>().SetTrigger("End");

        fade.SetTrigger("End");

        warpPlayer(player);
    }

    public AudioSource myAudioSource()
    {
        return musicToPlay;
    }

    private void warpPlayer(GameObject player)
    {
        if (target.GetComponent<we_warp>().exitDown())
        {
            player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - exitAmount, player.transform.position.z);
            animator.SetFloat("lastMoveVertical", -1f);
        }
        else
        {
            player.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + exitAmount, player.transform.position.z);
            animator.SetFloat("lastMoveVertical", 1f);
        }

        warping = false;
    }

    private void unfadeScreen()
    {
        fade.GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool exitDown()
    {
        return down;
    }
}
