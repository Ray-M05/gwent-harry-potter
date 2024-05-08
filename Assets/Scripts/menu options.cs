using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class menuoptions : MonoBehaviour
{
    // metodo para comenzar el juego
    public void Play_Game()
    {
        SceneManager.LoadScene(1);
    }

    // metodo para regresar al menu principal
    public void Play_Menu()
    {
        SceneManager.LoadScene(0);
    }
    // este metodo quita el juego en el ejecutable
    public void Quit_Game()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    //este metodo va a la escena de creditos
    public void Play_Credits()
    {
        SceneManager.LoadScene(2);
    }
}
