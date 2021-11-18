using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAnimator : MonoBehaviour
{
    public GameObject inventory;
    List<Animator> animators;
    public float WaitBetween = 0.15f;

    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());
    }

    void Update()
    {
        if (!inventory.activeInHierarchy)
        {
            StopCoroutine(DoAnimation());
        }

        else
        {
            StartCoroutine(DoAnimation());
        }
    }

    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(WaitBetween);
            }
        }
    }
}
