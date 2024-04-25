using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private Quaternion targetRotation;

    public Player_Character_Controller player;

    public float rotationSpeed;
    public Transform world;

    private float lastPlayerY;
    private float heightReductionFactor = 0.1f;

    public void OnPlayerDetected(Quaternion newTargetRotation)
    {
        world.transform.parent = null;

        transform.position = player.transform.position;
        world.transform.parent = transform;

        targetRotation = newTargetRotation;

        lastPlayerY = player.transform.position.y - heightReductionFactor;
        
    }

    private void Update()
    {
        if (targetRotation != transform.rotation)
        {
            if(player.transform.position.y < lastPlayerY)
            {
                player.transform.position = new Vector3(player.transform.position.x, lastPlayerY, player.transform.position.z);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
