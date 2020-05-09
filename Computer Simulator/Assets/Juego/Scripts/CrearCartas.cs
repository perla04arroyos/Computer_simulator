using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearCartas : MonoBehaviour
{
    public GameObject cartaPrefab;
    public int ancho;
    public Transform cartasParent;
    public List<GameObject> cartas = new List<GameObject>();
    public Texture2D[] texturas;

    public int contadorClicks;
    public Carta cartaMostrada;
    public bool sePuedeMostrar = true;
    public int numParejasEncontradas;

    public InterfazUI interfaz;
    public Text textoContadorIntentos;

    public void Reiniciar()
    {
        ancho = 0;
        cartas.Clear();
        GameObject[] cartasEliminar = GameObject.FindGameObjectsWithTag("Carta");
        for (int i = 0; i < cartasEliminar.Length; i++)
        {
            DestroyObject(cartasEliminar[i]);
        }
        contadorClicks = 0;
        textoContadorIntentos.text = "Intentos";
        cartaMostrada = null;
        sePuedeMostrar = true;
        numParejasEncontradas = 0;
        interfaz.ReiniciarCronometro();

        interfaz.ActivarCronometro();

        Crear();
    }

    public void Reiniciar2()
    {
        ancho = 0;
        cartas.Clear();
        GameObject[] cartasEliminar = GameObject.FindGameObjectsWithTag("Carta");
        for (int i = 0; i < cartasEliminar.Length; i++)
        {
            DestroyObject(cartasEliminar[i]);
        }
        contadorClicks = 0;
        textoContadorIntentos.text = "Intentos";
        cartaMostrada = null;
        sePuedeMostrar = true;
        numParejasEncontradas = 0;
        interfaz.ReiniciarCronometro();
    }

    public void Crear()
    {
        ancho = interfaz.dificultad;
        float factor = 9.0f / ancho;
        for (int i = 0; i < ancho; i++)
        {
            for (int j = 0; j < ancho; j++)
            {
                Vector3 posicionTemp = new Vector3(j * factor, 0, i * factor);

                GameObject cartaTemp = Instantiate(cartaPrefab, posicionTemp,
                    Quaternion.Euler(new Vector3(0, 180, 0)));

                cartaTemp.transform.localScale *= factor;

                cartas.Add(cartaTemp);

                cartaTemp.GetComponent<Carta>().posicionOriginal = posicionTemp;

                cartaTemp.transform.parent = cartasParent;                
            }
        }
        AsignarTexturas();
        Barajar();
    }

    public void AsignarTexturas()
    {
        /*int[] arrayTemp = new int[texturas.Length];
        for (int i = 0; i < arrayTemp.Length; i++)
        {
            int tmp = i;
            int r = Random.Range(i, arrayTemp.Length);
            arrayTemp[i] = r;
            arrayTemp[r] = tmp;
        }
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().AsignarTextura(texturas[arrayTemp[i/2]]);
            cartas[i].GetComponent<Carta>().idCarta = i/2;
        }*/

        int cont = 0;
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i].GetComponent<Carta>().AsignarTextura(texturas[i]);
            cartas[i].GetComponent<Carta>().idCarta = cont;
            if((i%2) != 0)
            {
                cont++;
            }
            
        }
    }

    void Barajar()
    {
        int aleatorio;
        for (int i = 0; i < cartas.Count; i++)
        {
            aleatorio = Random.Range(i, cartas.Count);

            cartas[i].transform.position = cartas[aleatorio].transform.position;
            cartas[aleatorio].transform.position = cartas[i].GetComponent<Carta>().posicionOriginal;

            cartas[i].GetComponent<Carta>().posicionOriginal = cartas[i].transform.position;
            cartas[aleatorio].GetComponent<Carta>().posicionOriginal = cartas[aleatorio].transform.position;
        }
    }

    public void HacerClick(Carta _carta)
    {
        if (cartaMostrada == null)
        {
            cartaMostrada = _carta;
        }
        else
        {
            contadorClicks++;
            ActalizarUI();
            if (CompararCartas(_carta.gameObject, cartaMostrada.gameObject))
            {
                print("Has encontrado una pareja!");
                numParejasEncontradas++;
                if (numParejasEncontradas == cartas.Count / 2)
                {
                    print("Has encontrado todas las parejas!");
                    interfaz.MostrarVistaGanar();
                    interfaz.EsconderFondo();
                }
            }
            else
            {
                _carta.EsconderCarta();
                cartaMostrada.EsconderCarta();
            }
            cartaMostrada = null;
        }     
    }

    public bool CompararCartas(GameObject carta1, GameObject carta2)
    {
        bool resultado;
        if (carta1.GetComponent<Carta>().idCarta == carta2.GetComponent<Carta>().idCarta)
        {
            resultado = true;
        }
        else
        {
            resultado = false;
        }
        return resultado;
    }

    public void ActalizarUI()
    {
        textoContadorIntentos.text = "Intentos: " + contadorClicks;
    }
}
