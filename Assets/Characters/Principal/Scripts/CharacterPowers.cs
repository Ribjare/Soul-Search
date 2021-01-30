using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowers : MonoBehaviour
{
    //Prefab references
    public GameObject personalitySensitivePrefat;
    public GameObject personalityBravePrefat;


    // Spawn Points
    public Transform wherePersonalitiesDrop;

    private bool hasPersonalitySensitive = false;
    private bool hasPersonalityBrave = false;


    Collider2D nearWall;

    private Rigidbody2D rb2D;
    private float thrust = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            // check is we have sensitive personality and are near wall
            if (nearWall && hasPersonalitySensitive)
            {
               nearWall.isTrigger = true;
               Instantiate(personalitySensitivePrefat, wherePersonalitiesDrop.position, Quaternion.identity);
               hasPersonalitySensitive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // check is we have sensitive personality and are near wall
            if (hasPersonalityBrave)
            {
                rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                Instantiate(personalityBravePrefat, wherePersonalitiesDrop.position, Quaternion.identity);
                hasPersonalityBrave = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall")) { 
            nearWall = collision;
            return;
        }
        if (collision.CompareTag("SensitivePersonality")){
            hasPersonalitySensitive = true;
            Destroy(collision.gameObject);

            return;
        }
        if (collision.CompareTag("BravePersonality"))
        {
            hasPersonalityBrave = true;
            Destroy(collision.gameObject);

            return;
        }
        if (collision.CompareTag("EndLevelDoor"))
        {
            Debug.Log(hasPersonalitySensitive);
            if (hasPersonalitySensitive) { 
                Debug.Log("abertop");
                collision.GetComponent<DoorController>().Open();
            }
            else { 
                collision.GetComponent<DoorController>().Close();
                Debug.Log("fecha");
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            nearWall = null;

    }
}
