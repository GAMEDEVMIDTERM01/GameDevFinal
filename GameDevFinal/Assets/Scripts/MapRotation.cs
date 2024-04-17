using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    public GameObject world;
    public GameObject player;

    /*
    bool canrotate = true;

    private void Update()
    {
        if (canrotate)
        {
            world.GetComponent<RotateWorld>().RotateWorldMethod(transform.localRotation);
        }
    }

    private void Awake()
    {
        StartCoroutine(RotatingMap());
    }
    */

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("player detected");
            world.GetComponent<RotateWorld>().RotateWorldMethod(transform.localRotation);
            
        }
    }

    
    /*
    IEnumerator RotatingMap()
    {
        canrotate = false;
        yield return new WaitForSeconds(5f);

        canrotate = true;
       
    }
    */

}