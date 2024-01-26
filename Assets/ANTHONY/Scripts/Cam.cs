using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public float minX = -0.7718472f; // Límite inferior para la cámara en el eje X

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
            float x = Mathf.Max(target.position.x + 6, minX);
            transform.position = new Vector3(x, target.position.y + 3.9f, transform.position.z);
        }
    }
}
