using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    
    public void Iniciar_Desk_Comp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Iniciar_Comp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);
    }

    public void Iniciar_Juego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 20);
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}