using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform targetTransform;
    public float followSpeed = 5f;
    public Vector3 offset = new Vector3(-7, 11, -7);

    void Start()
    {
        transform.rotation = Quaternion.Euler(45f, 45f, 0f);
    }

    void Update()
    {
        Vector3 targetPosition = targetTransform.position + offset;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
