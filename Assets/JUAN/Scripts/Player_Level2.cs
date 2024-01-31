using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Level2 : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;

    public Transform bubbleSpawnPoint;
    public GameObject bubblePrefab;
    public float bubbleSpeed = 10;

    private Rigidbody2D rb;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);
        rb.velocity = new Vector2(movimiento.x * velocidadMovimiento, rb.velocity.y);

        // Voltear el personaje
        if (movimientoHorizontal > 0 && !facingRight || movimientoHorizontal < 0 && facingRight)
        {
            Voltear();
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // Disparar
        if (Input.GetKeyDown(KeyCode.X))
        {
            var bubble = Instantiate(bubblePrefab, bubbleSpawnPoint.position, bubbleSpawnPoint.rotation);
            bubble.GetComponent<Rigidbody2D>().velocity = bubbleSpawnPoint.up * bubbleSpeed;
        }
    }

    void Voltear()
    {
        facingRight = !facingRight;
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }
}
