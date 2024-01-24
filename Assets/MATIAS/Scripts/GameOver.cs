using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    bool hasCollided = false;
    public GameObject pipesPrefab; // Asigna el Prefab de "Pipes" aquí desde el Editor

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipes") && !hasCollided)
        {
            // Reproduce la música de "Game Over"
            audioSource.Play();

            // Puedes agregar aquí cualquier otra lógica relacionada con el "Game Over"

            // Marca que ya ha ocurrido la colisión para evitar repetir la acción
            hasCollided = true;

            // Puedes desactivar el objeto PipesPrefab si lo prefieres
            pipesPrefab.SetActive(false);
        }
    }

}
