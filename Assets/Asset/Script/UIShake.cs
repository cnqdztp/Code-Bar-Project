using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShake : MonoBehaviour
{
    public float shakeSpeed = 1;

    public RectTransform rectObject;
    // Start is called before the first frame update
    void Start()
    {
        rectObject = gameObject.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
