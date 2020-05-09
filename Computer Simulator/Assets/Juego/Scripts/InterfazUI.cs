using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InterfazUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject vistaGanar;
    public GameObject vistaFondo;
    public bool menuMostrado;
    public bool vistaGanarMostrada;

    public Slider sliderDificultad;
    public Text textoDificultad;
    public int dificultad;

    public int segundosCronometro;
    public Text textoCronometro;
    TimeSpan tiempo;

    public Text textoGanar;

    void Start()
    {
        CambiarDificultad();
    }


    public void MostrarMenu()
    {
        menu.SetActive(true);
        menuMostrado = true;
    }

    public void EsconderMenu()
    {
        menu.SetActive(false);
        menuMostrado = false;
    }

    public void MostrarVistaGanar()
    {
        vistaGanar.SetActive(true);
        vistaGanarMostrada = true;
        //textoGanar.text = "Has Ganado en: " + tiempo.ToString();
    }

    public void EsconderVistaGanar()
    {
        vistaGanar.SetActive(false);
        vistaGanarMostrada = false;
    }

    public void MostrarFondo()
    {
        vistaFondo.SetActive(true);
    }

    public void EsconderFondo()
    {
        vistaFondo.SetActive(false);
    }

    public void CambiarDificultad()
    {
        dificultad = (int)sliderDificultad.value;
        textoDificultad.text = "Dificultad: " + dificultad;
    }

    public void ActivarCronometro()
    {
        ActualizarCronometro();
    }

    public void ReiniciarCronometro()
    {
        segundosCronometro = 0;
        textoCronometro.text = "0:00:00";
        CancelInvoke("ActualizarCronometro");
    }
    public void PausarCronometro()
    {

    }
    public void ActualizarCronometro()
    {
        segundosCronometro++;
        tiempo = new TimeSpan(0, 0, segundosCronometro);
        textoCronometro.text = tiempo.ToString();
        Invoke("ActualizarCronometro", 1.0f);
    }
    
}
