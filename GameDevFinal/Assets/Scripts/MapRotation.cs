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
        if (collision.gameObject == player)
        {
            Debug.Log("player detected");
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation, collision.transform, this.gameObject.GetComponent<BoxCollider>());
            
        }
    }



}