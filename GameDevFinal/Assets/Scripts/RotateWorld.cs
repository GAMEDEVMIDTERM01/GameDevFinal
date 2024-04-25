using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private Quaternion targetRotation;

    public float rotationSpeed;
    public Transform world;

    private BoxCollider rotationCollider;

    public void OnPlayerDetected(Quaternion newTargetRotation, Transform playerTransform, BoxCollider colliderDetected)
    {
        world.transform.parent = null;
        transform.position = playerTransform.position;
        world.transform.parent = transform;

        targetRotation = newTargetRotation;

        rotationCollider = colliderDetected;
        
    }

    private void Update()
    {
        if (targetRotation != transform.rotation)
        {

            rotationCollider.isTrigger = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rotationCollider.isTrigger = true;
        }
    }

}
