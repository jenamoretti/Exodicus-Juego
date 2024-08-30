using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraa : MonoBehaviour
{
    public Transform targetTransform;
    public float followSpeed;
    public float _xFollowDistance = 5f;
    public float _zFollowDistance = 5f;
    public float _followMoveThreshhold = 0.02f;
    void Start()
    {
        
    }

    void Update()
    {
        float xDistance = transform.position.x - targetTransform.position.x;
        float zDistance = transform.position.z - targetTransform.position.z;

        Vector3 newPosition = transform.position;

        float xMoveThreshold = Mathf.Abs(xDistance - _xFollowDistance);
        float zMoveThreshold = Mathf.Abs(zDistance - _zFollowDistance);

        if (xMoveThreshold > _followMoveThreshhold)
        {
            if (xDistance > _xFollowDistance)
            {
                newPosition.x -= transform.right.x;
            }
            else if (xDistance < _xFollowDistance)
            {
                newPosition.x += transform.right.x;
            }
        }

        if (zMoveThreshold > _followMoveThreshhold)
        {
            if (zDistance > _zFollowDistance)
            {
                newPosition.z -= transform.forward.z;
            }
            else
            {
                newPosition.z += transform.forward.z;
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
