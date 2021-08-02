using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIShake : MonoBehaviour
{
    public float shakeSpeed = 1;

    public RectTransform rectObject;
    // Start is called before the first frame update
    void Start()
    {
        this.rectObject.rotation = new Quaternion(0,0,0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rectObject.rotation.z > 0.3 || rectObject.rotation.z<-0.3)
        {
            shakeSpeed = -shakeSpeed;
            this.rectObject.Rotate(new Vector3(0,0,1)*Time.deltaTime*shakeSpeed);
        }
        this.rectObject.Rotate(new Vector3(0,0,1)*Time.deltaTime*shakeSpeed);
    }
}
