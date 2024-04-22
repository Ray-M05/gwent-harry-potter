using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCards : MonoBehaviour
{
    public GameManager GameManager;
    public hogwartsdeck hogwartsdeck1; //Gryff
    public hogwartsdeck hogwartsdeck2; //Slyth
    public cardaction cardaction;
    public int carta_mano; 
    public ChangeTurn ChangeTurn;
    public GameObject GameObject; //el propio boton

    public void Cambiar_carta() //boton que permite cambiar dos cartas aleatorias una sola vez, puede usarse en cualquier momento del juego
    {
        
        System.Random rand = new System.Random(); 
        int a = rand.Next(0, hogwartsdeck1.Hand.Count); //crea un random del tamaño del deck
        int b = rand.Next(0, hogwartsdeck1.Hand.Count-1); //una pos menos del deck para evitar que elimine la carta que se agrego
        if (GameManager.turn == "Gryff") //confirma a quien le pertenece el turno
        {
            hogwartsdeck1.Hand.RemoveAt(a);
            hogwartsdeck1.Hand.RemoveAt(b);
            hogwartsdeck1.rob(2);
            GameObject.SetActive(false); //desactiva el boton para evitar su uso
            ChangeTurn.Gryff_changeit = true; //confirma que se realizo el cambio
        }
        else // si el turno le pertenece al otro jugador
        {
            
            hogwartsdeck2.Hand.RemoveAt(a);
            hogwartsdeck2.Hand.RemoveAt(b);
            hogwartsdeck2.rob(2);
            GameObject.SetActive(false); 
            ChangeTurn.Slyth_changeit = true;
        }
            

        
        
    }
}
