using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = Camera.main.transform.rotation;
        // gameObject.transform.rotation = Camera.main.transform.rotation;
    }
}
