using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    public GameObject world;
    public GameObject player;

    //public GameObject[] rotationColliders;

    //private Transform bestRotation;
    //private Quaternion colliderRotation;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            //Debug.Log("theres a collision detected");
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation);
            //colliderRotation = transform.localRotation;
        }
    }

    /*

    void GetClosestRotation(GameObject[] colliders)
    {
        Vector3 currentPosition = player.transform.position;
        foreach (GameObject potentialRotation in colliders)
        {
            Transform potentialRotationTransform = potentialRotation.transform;
            Vector3 directionToTarget = potentialRotationTransform.position;
            if (directionToTarget == currentPosition)
            {
                bestRotation = potentialRotationTransform;
            }
        }

        if(bestRotation == transform)
        {
            Debug.Log("player hit position with collision detection");
            world.GetComponent<RotateWorld>().OnPlayerDetected(colliderRotation);
        }
        else
        {
            Debug.Log("player hit position without collision detection");
            world.GetComponent<RotateWorld>().OnPlayerDetected(bestRotation.localRotation);
        }
    }

    private void FixedUpdate()
    {
        GetClosestRotation(rotationColliders);
    }
    */
}