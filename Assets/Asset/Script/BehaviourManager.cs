using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Waypoint;
    private Transform[] Waypoints;
    private new Vector3 targetPosition;
    private new Vector3 direction;
    private Animator spriteAnimator;
    private new Vector3 walkDirection;
    public float paceSpeed = 1;
    void Start()
    {
        spriteAnimator = GetComponent<Animator>();
        Waypoints = new Transform[Waypoint.transform.childCount];
        for (int i = 0; i <= Waypoint.transform.childCount-1; i++)
        {
            Waypoints[i] = Waypoint.transform.GetChild(i);
        }
        InvokeRepeating("BehaviourRandomizer",1f,10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(targetPosition, gameObject.transform.position) >= 0.5)
        {
            gameObject.transform.position += direction * (Time.deltaTime * paceSpeed);
            spriteAnimator.SetFloat("Normalized_Direction",walkDirection.z*10);
        }
        else
        {
            spriteAnimator.SetFloat("Normalized_Direction",0);
        }
    }

    void BehaviourRandomizer()
    {
        //Currently the operator only choose to wander
        Wander();
    }
    
    void Wander()
    {
        int targetNum = Random.Range(0, Waypoint.transform.childCount);
        Navigate(Waypoints[targetNum].transform.position);
        // var position = gameObject.transform.position;
        // gameObject.transform.position = position;
    }
    
    void Navigate(Vector3 _postion)
    {
        // print("New target Received");
        // print(position);
        // print(gameObject.transform.position);
        targetPosition = _postion;
        direction = targetPosition - gameObject.transform.position;
        direction = direction.normalized;
        
        // print(direction);
        walkDirection = targetPosition - gameObject.transform.localPosition;
    }
}
