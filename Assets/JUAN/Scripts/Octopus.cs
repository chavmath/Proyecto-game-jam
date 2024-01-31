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

            // Verifica si se ha alcanzado el límite de 10 burbujas
            if (bubbleCount >= 50)
            {
                // Si se alcanza el límite, reinicia el contador y destruye el pulpo
                bubbleCount = 0;
                Destroy(gameObject);
            }
        }

        // Verifica si el jugador ha sido destruido por el pulpo
        if (other.CompareTag("Player"))
        {
            // Reinicia el contador al matar al jugador
            bubbleCount = 0;
            // Puedes agregar aquí cualquier otra lógica para tratar la muerte del jugador
        }
    }
}
