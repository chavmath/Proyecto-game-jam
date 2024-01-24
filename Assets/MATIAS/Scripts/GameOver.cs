using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    bool hasCollided = false;
    public GameObject pipesPrefab; // Asigna el Prefab de "Pipes" aqu� desde el Editor

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipes") && !hasCollided)
        {
            // Reproduce la m�sica de "Game Over"
            audioSource.Play();

            // Puedes agregar aqu� cualquier otra l�gica relacionada con el "Game Over"

            // Marca que ya ha ocurrido la colisi�n para evitar repetir la acci�n
            hasCollided = true;

            // Puedes desactivar el objeto PipesPrefab si lo prefieres
            pipesPrefab.SetActive(false);
        }
    }

}
