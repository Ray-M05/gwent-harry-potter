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

    public void invocarCuerpoacuerpo() //boton de cuerpo a cuerpo en el panel de invocaciones
    {
        Carta.invocar(1); //cartas de oro y plata en cuerpo a cuerpo
        Carta.invocar(4); //aumento pos cuerpo a cuerpo
        Carta.invocar(7); //clima afecta cuerpo a cuerpo
        Carta.invocar(11); //señuelo en cuerpo a cuerpoo
    }

    public void invocarDistancia() //boton de Distancia en el panel de invocaciones
    {
      Carta.invocar(2); //cartas
      Carta.invocar(5);  //aumento
      Carta.invocar(8); //clima
      Carta.invocar(12); //señuelo
    }

    public void invocarAsedio() //boton de Asedio en el panel de invocaciones
    {
        Carta.invocar(3);
        Carta.invocar(6);
        Carta.invocar(9);
        Carta.invocar(13);
    }

    public void invocarDespeje() //boton de despeje
    {
        Carta.invocar(10);
    }
}
