using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonaction : MonoBehaviour
{
    public GameObject panel;
    public cardaction Carta;
    
    public void invocacion() 
        //activa el menu de opciones cuando se presiona el boton de invocacion
    {
        gameObject.SetActive(false);
        panel.SetActive(true);
        panel.GetComponent<Buttonaction>().Carta = Carta;

    
    }

    public void invocarCuerpoacuerpo()
    {
        Carta.invocar(1);
        Carta.invocar(4); 
    }

    public void invocarDistancia()
    {
      Carta.invocar(2);
      Carta.invocar(5); 
    }

    public void invocarAsedio()
    {
        Carta.invocar(3);
        Carta.invocar(6);
    }

    public void invocarAumento()
    {
        Carta.invocar(7);
    }
}
