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
        
       
    }

    public void invocarDistancia()
    {
      Carta.invocar(2);
       
    }

    public void invocarAsedio()
    {
        Carta.invocar(3);
     
    }


    
}
