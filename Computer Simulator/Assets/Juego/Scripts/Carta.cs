using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public int idCarta;
    public Vector3 posicionOriginal;
    public Texture2D texturaAnverso;
    public Texture2D texturaReverso;

    public bool mostrando;
    public float tiempoDelay;
    public GameObject crearCartas;

    public GameObject interfaz;

    void Awake()
    {
        crearCartas = GameObject.Find("Scripts");
        interfaz = GameObject.Find("Scripts");
    }

    void Start()
    {
        EsconderCarta();
    }

    void OnMouseDown()
    {
        if (!interfaz.GetComponent<InterfazUI>().menuMostrado)
        {
            MostrarCarta();
            print(idCarta.ToString());
        }
    }

    public void AsignarTextura(Texture2D _textura)
    {
        texturaAnverso = _textura;
    }

    public void MostrarCarta()
    {
        if (!mostrando && crearCartas.GetComponent<CrearCartas>().sePuedeMostrar)
        {
            mostrando = true;
            GetComponent<MeshRenderer>().material.mainTexture = texturaAnverso;
            crearCartas.GetComponent<CrearCartas>().HacerClick(this);
        } 
    }

    public void EsconderCarta()
    {
        Invoke("Esconder", tiempoDelay);
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = false;
    }

    public void Esconder()
    {
        GetComponent<MeshRenderer>().material.mainTexture = texturaReverso;
        mostrando = false;
        crearCartas.GetComponent<CrearCartas>().sePuedeMostrar = true;
    }

}
