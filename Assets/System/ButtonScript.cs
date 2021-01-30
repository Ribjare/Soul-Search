using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public MovablePlaform platform;

    public Animator animator;

    private bool isNearPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if (isNearPlayer) { 
            if (Input.GetButtonDown("ButtonPress"))
            {

                platform.Activate();
                animator.SetBool("IsPressed", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearPlayer = true; 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearPlayer = false;
    }
}
