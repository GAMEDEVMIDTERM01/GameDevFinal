using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    private void RotateWorldMethod(Vector3 degrees)
    {
        transform.Rotate(degrees);
    }

}
