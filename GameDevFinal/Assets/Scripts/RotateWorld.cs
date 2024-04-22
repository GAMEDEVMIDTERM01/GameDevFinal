using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private Quaternion targetRotation;

    public float rotationSpeed;
    public Transform world;

    public void OnPlayerDetected(Quaternion newTargetRotation, Transform playerTransform)
    {
        world.transform.parent = null;
        transform.position = playerTransform.position;
        world.transform.parent = transform;

        targetRotation = newTargetRotation;
        
    }

    private void Update()
    {
        if (targetRotation != transform.rotation)
        {

            //TO DO: Rotate around the currentRotationAxis to reach the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
