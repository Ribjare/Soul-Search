using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowers : MonoBehaviour
{

    Collider2D nearWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (nearWall)
            {
                nearWall.isTrigger = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearWall = collision;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nearWall = null;

    }
}
