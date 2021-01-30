using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlameToGilberto : MonoBehaviour
{
    //Prefab Reference
    public GameObject mainCharacter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SensitivePersonality"))
        {
            Instantiate(mainCharacter, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
