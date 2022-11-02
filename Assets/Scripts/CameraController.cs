using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform transform)
    {
        target = transform;
    }
    public void LooKAtTarget()
    {
        transform.position = new Vector3(
            target.position.x + 2,
            target.position.y + 3, 
            target.position.z + 3.5f);
    }
}
