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
           // Debug.Log("theres a collision detected " + transform.localRotation);
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag(player.tag))
    //    {
    //        // Debug.Log("theres a collision detected " + transform.localRotation);
    //        world.GetComponent<RotateWorld>().GetClosestRotation();
    //    }
    //}

}