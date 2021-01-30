using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Animator animator;

    public void Open()
    {
        Debug.Log("open");
        animator.SetBool("Completed", true);
        GetComponent<Collider2D>().enabled = false;

    }
    public void Close()
    {
        animator.SetBool("Completed", false);
        GetComponent<Collider2D>().enabled = true;

    }
}
