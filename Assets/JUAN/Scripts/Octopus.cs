using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    private int bubbleCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            // Incrementa el contador cuando colisiona con una burbuja
            bubbleCount++;

            // Destruye la burbuja
            Destroy(other.gameObject);

            // Verifica si se ha alcanzado el l�mite de 10 burbujas
            if (bubbleCount >= 50)
            {
                // Si se alcanza el l�mite, reinicia el contador y destruye el pulpo
                bubbleCount = 0;
                Destroy(gameObject);
            }
        }

        // Verifica si el jugador ha sido destruido por el pulpo
        if (other.CompareTag("Player"))
        {
            // Reinicia el contador al matar al jugador
            bubbleCount = 0;
            // Puedes agregar aqu� cualquier otra l�gica para tratar la muerte del jugador
        }
    }
}
