using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Animator animator;
    public bool checkForSensitive;
    public bool checkForBrave;
    private bool personalityCheck = false;

    // Opens the door
    public void Open()
    {
        Debug.Log("open");
        animator.SetBool("Completed", personalityCheck);
        var lsit = GetComponents<Collider2D>();

        foreach (Collider2D elem in lsit)
        {
            elem.enabled = false;
        }
        
    }
    // Closes the door
    public void Close()
    {
        animator.SetBool("Completed", personalityCheck);
        GetComponent<Collider2D>().enabled = true ;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var gameObject = collision.gameObject;
            var character = gameObject.GetComponent<CharacterPowers>();

       
            if (checkForSensitive && checkForBrave)
            {
                personalityCheck = character.HasPersonalityBrave && character.HasPersonalitySensitive;
            }
            else if (checkForBrave)
            {
                personalityCheck = character.HasPersonalityBrave;
            }
            else if (checkForSensitive)
            {
                personalityCheck = character.HasPersonalitySensitive;
            }

            if (personalityCheck)
            {
                Open();
            }
            else
            {
                Close();
            }

        }

    }
}
