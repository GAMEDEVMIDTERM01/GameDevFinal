using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    public GameObject world;
    public GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            //Debug.Log("theres a collision detected");
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation);
            
        }
    }

}