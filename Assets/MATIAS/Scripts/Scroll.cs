using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;

    private Rigidbody2D rb; // Corregir el nombre del tipo
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Corregir el nombre del tipo
        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameOver)
        {
            rb.velocity = Vector2.zero;
        }

    }
}
