using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento
    public float jumpForce = 5.0f; // Fuerza del salto
    private int isJumping = 0; // Para controlar el salto
    private UnityArmatureComponent armatureComponent; // Para controlar las animaciones
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente UnityArmatureComponent
        armatureComponent = GetComponent<UnityArmatureComponent>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Manejar el movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Reproducir la animación de caminar si el personaje se está moviendo
        if (Mathf.Abs(horizontalInput) > 0.1f && isJumping == 0)
        {
            if (armatureComponent.animation.lastAnimationName != "caminar")
            {
                armatureComponent.animation.FadeIn("caminar", -1, -1);
                armatureComponent.animation.timeScale = 2.0f; // Doble de rápido
            }
        }
        else
        {
            // Si no está caminando, reproducir la animación de estar quieto
            if (armatureComponent.animation.lastAnimationName != "estar_quieto")
            {
                armatureComponent.animation.FadeIn("estar_quieto", -1, -1);
                armatureComponent.animation.timeScale = 1.0f; // Velocidad normal
            }
        }

        // Manejar el salto
        if (Input.GetButtonDown("Jump") && isJumping < 2) // Permitir dos saltos
        {
            // Reproducir la animación de salto y ajustar la velocidad
            armatureComponent.animation.FadeIn("volar", -1, 1);
            armatureComponent.animation.timeScale = 0.5f;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping++;
        }
    }



    // Detectar cuando el objeto toca el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = 0;
            armatureComponent.animation.FadeIn("caminar", -1, -1);
            armatureComponent.animation.timeScale = 2.0f; // Doble de rápido
        }
    }
}
