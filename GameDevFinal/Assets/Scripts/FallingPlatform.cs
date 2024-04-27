using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.name == "player")
            isFalling = true;
        Destroy(gameObject, 10);
       
    }
 

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime/20;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed, transform.position.z);
        }
        
    }
}
