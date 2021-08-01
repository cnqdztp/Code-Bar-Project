using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateSprite : MonoBehaviour
{
    // Start is called before the first frame update
    private new Vector3 position;
    private new Vector3 direction;
    public float paceSpeed = 1;
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // print(Vector3.Distance(position, gameObject.transform.position));
        // print(gameObject.transform.position);
        // print(position);
        if (Vector3.Distance(position, gameObject.transform.position) >= 0.5)
        {
            gameObject.transform.position += direction * (Time.deltaTime * paceSpeed);
        }
    }

    void Navigate(Vector3 _postion)
    {
        print("New target Received");
        print(position);
        print(gameObject.transform.position);
        position = _postion;
        direction = position - gameObject.transform.position;
        direction = direction.normalized;
    }
}
