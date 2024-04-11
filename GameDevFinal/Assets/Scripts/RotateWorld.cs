using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public void RotateWorldMethod(float degrees)
    {
        transform.Rotate(0, 0, degrees);
    }

}
