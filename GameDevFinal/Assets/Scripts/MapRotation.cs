using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotation : MonoBehaviour
{

    public GameObject world;
    public GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            //world.GetComponent<GameObject>().RotateWorldMethod(transform.rotation);
            
        }
    }
}