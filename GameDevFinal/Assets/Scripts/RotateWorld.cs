using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private Quaternion targetRotation;

    public Player_Character_Controller player;

    public Transform[] rotationColliders;

    private Transform bestRotation;
    private Quaternion updatedRotation;


    public float rotationSpeed;
    public Transform world;

    private float lastPlayerY;
    private float playerBorderY;
    private float heightReductionFactor = 0.1f;



    public void OnPlayerDetected(Quaternion newTargetRotation)
    {
        world.transform.parent = null;

        transform.position = player.transform.position;
        world.transform.parent = transform;

        targetRotation = newTargetRotation;

        lastPlayerY = player.transform.position.y;
        playerBorderY = lastPlayerY - heightReductionFactor;
    }

    void GetClosestRotation(Transform[] colliders)
    {
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = player.transform.position;
        foreach (Transform potentialRotation in colliders)
        {
            Vector3 directionToTarget = potentialRotation.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestRotation = potentialRotation;
            }
        }
        updatedRotation = bestRotation.localRotation;
    }

    private void Update()
    {
        if(player.isGrounded && transform.rotation == targetRotation)
        {
            GetClosestRotation(rotationColliders);
        }
        
        
        if (targetRotation == updatedRotation)
        {
            if (targetRotation != transform.rotation)
            {
                if (player.transform.position.y < playerBorderY)
                {
                    player.transform.position = new Vector3(player.transform.position.x, lastPlayerY, player.transform.position.z);
                }
                //Debug.Log("calling the closest position one instead");
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            else
            {
                if (updatedRotation != transform.rotation)
                {
                    if (player.transform.position.y < playerBorderY)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, lastPlayerY, player.transform.position.z);
                    }
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, updatedRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }

        else if (targetRotation != transform.rotation)
        {
            //Debug.Log("calling the normal one");
            if (player.transform.position.y < playerBorderY)
            {
                player.transform.position = new Vector3(player.transform.position.x, lastPlayerY, player.transform.position.z);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

}
