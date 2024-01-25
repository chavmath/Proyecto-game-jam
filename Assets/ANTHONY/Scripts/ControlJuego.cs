using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip audioClip; // Referencia al clip de audio
    public GameObject jugador; // Prefab del cuadrado


    ///TEMPORIZADOR
    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivo = true;
    [SerializeField] private Slider slider;


    //PARA MOSTRAR MODALES
    public Canvas modalPerder;
    public Canvas modalGanar;

    //PARA BOTONES
    public Button botonAceptar;
    public Button botonAceptaGanar;

    public TextMeshProUGUI contadorBloquesAzulText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesMoradoText; // Un objeto Text para mostrar el conteo de bloques

    public int bloquesDestruidosMorado = 5; // Variable para llevar el conteo de bloques morados destruidos
    public int bloquesDestruidosAzul = 5; // Variable para llevar el conteo de bloques azules destruidos

    // M�todos para incrementar el contador de bloques destruidos por color
    public void IncrementarBloquesDestruidosMorado()
    {
        if (bloquesDestruidosMorado != 0)
        {
            bloquesDestruidosMorado--;
            contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
        }
    }

    public void IncrementarBloquesDestruidosAzul()
    {
        if (bloquesDestruidosAzul != 0)
        {
            bloquesDestruidosAzul--;
            contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        // Reproduce el audio
        audioSource.PlayOneShot(audioClip);

        // Configurar el temporizador y el n�mero de shurikens
        tiempoMaximo = 20; ;
        // Configurar el temporizador y el n�mero de bloques de cada color
        bloquesDestruidosMorado = 10;
        bloquesDestruidosAzul = 10;
        ActivarTemporizador();
        // Asigna el evento de clic al bot�n
        botonAceptar.onClick.AddListener(RestablecerNivelUno);


    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoActivo)
        {
            CambiarContador();

        }

        if (bloquesDestruidosAzul + bloquesDestruidosMorado  == 0)
        {
            DesactivarTemporizador();
            // Activa el canvas modalGanar si existe
            modalGanar.gameObject.SetActive(true);

        }

    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }
        if (tiempoActual <= 0)
        {

            if (modalPerder != null)
            {
                // Activa el canvas modalPerder si existe
                modalPerder.gameObject.SetActive(true);
            }
            tiempoActivo = false;
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivo = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }

    public void RestablecerNivelUno()
    {
    

       
        // Restablecer el temporizador y el n�mero de bloques de cada color
        tiempoMaximo = 50;
        bloquesDestruidosMorado = 10;
        bloquesDestruidosAzul = 10;

        // Restablecer los contadores de bloques destruidos
        contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
        contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;

   
        // Restablecer el temporizador
        ActivarTemporizador();
    }



}
