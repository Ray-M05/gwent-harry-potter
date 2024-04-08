using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonaction : MonoBehaviour
{
    public GameObject panel;
    public cardaction Carta;
    public GameManager GameManager;
    
    public void invocacion() 
        //activa el menu de opciones cuando se presiona el boton de invocacion
    {
        
            gameObject.SetActive(false);
            panel.SetActive(true);
            panel.GetComponent<Buttonaction>().Carta = Carta;
        
    
    }

    public void invocarCuerpoacuerpo()
    {
        Carta.invocar(1); //cartas cuerpo a cuerpo
        Carta.invocar(4); //aumento pos cuerpo a cuerpo
        Carta.invocar(7); //clima afecta cuerpo a cuerpo
    }

    public void invocarDistancia()
    {
      Carta.invocar(2); //cartas
      Carta.invocar(5);  //aumento
      Carta.invocar(8); //clima
    }

    public void invocarAsedio()
    {
        Carta.invocar(3);
        Carta.invocar(6);
        Carta.invocar(9);
    }

    public void invocarDespeje()
    {
        Carta.invocar(10);
    }
}
