using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public float minY = -0.7718472f; // Límite inferior para la cámara

    private void Start()
    {

    }

    private void Update()
    {

    }
    void LateUpdate()
    {
        if (target != null)
        {
            float y = Mathf.Max(target.position.y + 3.9f, minY);
            transform.position = new Vector3(target.position.x + 6, y, transform.position.z);
        }
    }
}
