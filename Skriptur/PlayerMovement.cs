using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=100f;
    public float sideways = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
           
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * sideways * Time.deltaTime;
          
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += -transform.right * sideways * Time.deltaTime;
          
        }
        if (Input.GetKey("a"))
        {
            Vector3 snu = new Vector3(0, 2, 0);
            transform.Rotate(snu, Space.World);
        }
        if (Input.GetKey("s"))
        {
            Vector3 snu = new Vector3(0, -2, 0);
            transform.Rotate(snu, Space.World);
        }
    }
}
