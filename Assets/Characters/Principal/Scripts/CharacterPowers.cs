using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowers : MonoBehaviour
{
    //Prefab references
    public GameObject personalityPrefat;

    // Spawn Points
    public Transform wherePersonalitiesDrop;

    private bool hasPersonality = false;

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
            // check is we have sensitive personality and are near wall
            if (nearWall && hasPersonality)
            {
               nearWall.isTrigger = true;
               Instantiate(personalityPrefat, wherePersonalitiesDrop.position, Quaternion.identity);
               hasPersonality = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")) { 
            nearWall = collision;
        }
        if (collision.CompareTag("Personality")){
            hasPersonality = true;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            nearWall = null;

    }
}
