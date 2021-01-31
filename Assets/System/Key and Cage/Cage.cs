using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key")) {
            FindObjectOfType<AudioManager>().Play("AbrirGaiola");

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
