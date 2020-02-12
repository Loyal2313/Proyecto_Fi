# Proyecto_Fi
using System.Collections;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour{
    
    public void MainMenu()
    {
        Application.LoadLevel("menu");
    }

    
    public void Play()
    {
        Application.LoadLevel("JuegoFi");
    }

    public void Quit()
    {
        Application.Quit();
    }

}