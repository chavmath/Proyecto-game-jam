using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalWin : MonoBehaviour


{

    public float fuerzaDeAtraccion = 10f; // Fuerza de atracción del portal
                                          //PARA MOSTRAR MODALES
    public Canvas modalGanar;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Comprobamos si el objeto que ha entrado en el trigger es el jugador
        if (other.gameObject.activeSelf)
        {
            //Imprimimos en consola el nombre del objeto que ha entrado en el trigger
            Debug.Log("Ha entrado en el trigger el objeto: " + other.gameObject.name);

            // Calcula la dirección hacia el centro del portal
            Vector2 direccion = (transform.position - other.transform.position).normalized;

            // Aplica una fuerza al jugador en la dirección del portal
            other.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaDeAtraccion);
        }

        if (other.gameObject.CompareTag("Jugador"))
        {
            //Imprimimos en consola el nombre del objeto que ha entrado en el trigger
            Debug.Log("Ha entrado en el trigger el objeto: " + other.gameObject.name);

            // Calcula la dirección hacia el centro del portal
            Vector2 direccion = (transform.position - other.transform.position).normalized;

            // Aplica una fuerza al jugador en la dirección del portal
            other.GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaDeAtraccion);

            // Activa el canvas modalGanar si existe
            modalGanar.gameObject.SetActive(true);
            SceneManager.LoadScene("Nivel 1 Story");
        }
    }

}
