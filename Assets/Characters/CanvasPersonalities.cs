using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPersonalities : MonoBehaviour
{
    public GameObject sensitiveImg;
    public GameObject braveImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void setSensitiveActive(bool active)
    {
        sensitiveImg.SetActive(active);
    }
    public void setBraveActive(bool active)
    {
        braveImg.SetActive(active);
    }
}
