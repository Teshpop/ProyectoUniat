using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimExit : MonoBehaviour
{
    public Animator animator;
    public void StopBool(bool a)
    {
        animator.SetBool("ATQING", a);
    }
}
