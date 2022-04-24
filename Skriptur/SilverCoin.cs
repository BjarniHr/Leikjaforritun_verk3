using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoin : MonoBehaviour
{   
    private float startYPos;
    // Hér set ég peninginn svo hann snýr og fer upp og niðurx
    [SerializeField] [Range(0,1)] float speed = 0.5f;
    [SerializeField] [Range(0,100)] float range = 1f; 
    void Start() 
    {
        startYPos = transform.position.y;
        Debug.Log(startYPos);
    }
    void Update()
    {
        // rotatin
        transform.Rotate(new Vector3(0,0,80) * Time.deltaTime);
        //transform.position += transform.forward * 0.1;
        loop();
    }
    void loop()
    {
        float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
        transform.position = new Vector3(transform.position.x, yPos + startYPos, transform.position.z);
    }
}