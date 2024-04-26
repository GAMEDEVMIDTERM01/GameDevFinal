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
            world.GetComponent<RotateWorld>().OnPlayerDetected(transform.localRotation);

            StartCoroutine(adjustRotation(transform.localRotation));
            
        }
    }

    IEnumerator adjustRotation(Quaternion rotation)
    {
       yield return new WaitForSeconds(0.1f);


        // maybe have 2 conditions, one when raycast is hitting one when not

        if (player.GetComponent<Player_Character_Controller>().shouldRotate && rotation != world.transform.rotation)
        {
            Debug.Log("helping rotate is getting called");
            world.GetComponent<RotateWorld>().OnPlayerDetected(rotation);
        }
    }
}