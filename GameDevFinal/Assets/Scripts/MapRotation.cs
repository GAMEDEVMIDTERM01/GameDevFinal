using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{
    public GameObject world;
    public GameObject player;

    //public Quaternion[] rotationColliders;

    //private Quaternion bestRotation;
    //private Quaternion colliderRotation;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(player.tag))
        {
            Debug.Log("theres a collision detected");
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation);

            //colliderRotation = transform.localRotation;
        }
    }

    //void GetClosestRotation(Quaternion[] colliders)
    //{
    //    float closestDistanceSqr = Mathf.Infinity;
    //    Vector3 currentPosition = player.transform.position;
    //    foreach (Transform potentialRotation in colliders)
    //    {
    //        Vector3 directionToTarget = potentialRotation.position - currentPosition;
    //        float dSqrToTarget = directionToTarget.sqrMagnitude;
    //        if (dSqrToTarget < closestDistanceSqr)
    //        {
    //            closestDistanceSqr = dSqrToTarget;
    //            bestRotation = potentialRotation;
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    GetClosestRotation(rotationColliders);
    //}


}