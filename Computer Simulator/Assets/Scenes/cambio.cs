using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambio : MonoBehaviour
{
    public void CambioEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
