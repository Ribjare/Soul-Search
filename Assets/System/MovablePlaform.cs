using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlaform : MonoBehaviour
{
    public Transform destinationTransform;
    public GameObject platform;
    public float speed = 1.0f;
    private bool isActive = false;

    public void Activate()
    {
        isActive = true;
        FindObjectOfType<AudioManager>().Play("PlataformaAMover");

    }
    private void Update()
    {
        if(isActive)
            platform.transform.Translate(Vector2.down * speed * Time.deltaTime);
        else
        {
            platform.transform.Translate(new Vector2());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = false;
    }
}
