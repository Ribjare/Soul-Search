using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    //When Player leave it's area, he goes back to being a normal collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("saiu da parede");
        GetComponent<Collider2D>().isTrigger = false;
    }
}
