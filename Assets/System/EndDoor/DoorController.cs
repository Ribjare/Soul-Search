using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Animator animator;

    public void Open()
    {
        animator.SetBool("Completed", true);

    }
    public void Close()
    {
        animator.SetBool("IsJumping", false);

    }
}
