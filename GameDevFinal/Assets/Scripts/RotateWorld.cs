using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public Quaternion targetRotation;

    public void RotateWorldMethod(Quaternion degrees)
    {
        targetRotation = degrees;        
    }

    private void Update()
    {
        if (targetRotation != transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 200f * Time.deltaTime);
        }
    }

}
