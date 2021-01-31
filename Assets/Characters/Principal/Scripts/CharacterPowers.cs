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

    public bool hasPersonalitySensitive = false;
    public bool hasPersonalityBrave = false;


    Collider2D nearWall;

    private Rigidbody2D rb2D;
    private float thrust = 10.0f;

    public bool HasPersonalitySensitive { get => hasPersonalitySensitive; set => hasPersonalitySensitive = value; }
    public bool HasPersonalityBrave { get => hasPersonalityBrave; set => hasPersonalityBrave = value; }

    public GameObject canvasObject;
    private CanvasPersonalities canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
        foreach (Canvas c in FindObjectsOfType<Canvas>())
        {
            if (c.CompareTag("MainCamera"))
            {
                canvas = c.GetComponent<CanvasPersonalities>();
                break;
            }
        }
        //initializes the canvas
        canvas.setSensitiveActive(HasPersonalitySensitive);
        canvas.setBraveActive(HasPersonalityBrave);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            // check is we have sensitive personality and are near wall
            if (nearWall && HasPersonalitySensitive)
            {
               nearWall.isTrigger = true;
               Instantiate(personalitySensitivePrefat, wherePersonalitiesDrop.position, Quaternion.identity);
               HasPersonalitySensitive = false;
               canvas.setSensitiveActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // check is we have sensitive personality and are near wall
            if (HasPersonalityBrave)
            {
                rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                Instantiate(personalityBravePrefat, wherePersonalitiesDrop.position, Quaternion.identity);
                HasPersonalityBrave = false;
                canvas.setBraveActive(false);

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
            HasPersonalitySensitive = true;
            canvas.setSensitiveActive(true);

            Destroy(collision.gameObject);

            return;
        }
        if (collision.CompareTag("BravePersonality"))
        {
            HasPersonalityBrave = true;
            canvas.setBraveActive(true);
            Destroy(collision.gameObject);

            return;
        }
        /**
        if (collision.CompareTag("EndLevelDoor"))
        {
            Debug.Log(HasPersonalitySensitive);
            if (HasPersonalitySensitive) { 
                Debug.Log("abertop");
                collision.GetComponent<DoorController>().Open();
            }
            else { 
                collision.GetComponent<DoorController>().Close();
                Debug.Log("fecha");
            }

        }
        */
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
            nearWall = null;

    }
}
