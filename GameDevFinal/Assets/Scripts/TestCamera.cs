using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour

{

    public Transform playerTransform;
    public Vector3 offset;


    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 targetposition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);

            transform.position = targetposition + offset;
        }
    }
}

