using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public void leftFootstep()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("StepLeft");
    }

    public void rightFootstep()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("StepRight");
    }
}
