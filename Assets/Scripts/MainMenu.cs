using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void EscenaJuego()
    {
        SceneManager.LoadScene("FinalProg");
    }

    public void CargarNivel(string nombreNivel1)
    {
        SceneManager.LoadScene(nombreNivel1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
