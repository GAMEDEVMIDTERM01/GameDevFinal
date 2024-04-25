using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private Quaternion targetRotation;

    public float rotationSpeed;
    public Transform world;

    public Player_Character_Controller myPlayer;

    private float _lastPlayerHeight;

    public void OnPlayerDetected(Quaternion newTargetRotation)
    {
        Debug.Log(newTargetRotation);
        world.transform.parent = null;
        transform.position = myPlayer.transform.position;
        world.transform.parent = transform;

        targetRotation = newTargetRotation;
        _lastPlayerHeight = myPlayer.transform.position.y;
        
    }

    private void Update()
    {
        if (targetRotation != transform.rotation)
        {
            if(myPlayer.transform.position.y < _lastPlayerHeight)
            {
                myPlayer.transform.position = new Vector3(myPlayer.transform.position.x, _lastPlayerHeight, myPlayer.transform.position.z);
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}
