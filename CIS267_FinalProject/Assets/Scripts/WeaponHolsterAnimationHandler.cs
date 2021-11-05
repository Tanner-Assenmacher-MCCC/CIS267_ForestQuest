using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolsterAnimationHandler : MonoBehaviour
{
    public Animator animator;
    SpriteRenderer render;
    Transform t;
    Quaternion tRotation;
    Vector3 tScale;

    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        t = gameObject.GetComponent<Transform>();
        tRotation = t.rotation;
        tScale = t.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        animationRefresh();
    }

    private void animationRefresh()
    {
        if (animator.GetFloat("lastMoveHorizontal") == 1)
        {

        }

        if (animator.GetFloat("lastMoveHorizontal") == -1)
        {

        }

        if (animator.GetFloat("lastMoveVertical") == -1)
        {
            tRotation.z = 225;
            render.sortingOrder = 1;
        }

        if (animator.GetFloat("lastMoveVertical") == 1)
        {
            tRotation.z = 135;
            render.sortingOrder = 3;
        }
    }
}
