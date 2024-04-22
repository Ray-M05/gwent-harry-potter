using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeTurn : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject GryffReverse;
    public GameObject HandG;
    public GameObject SlythReverse;
    public GameObject HandS;
    public ChangeCards ChangeCards;

    public bool Gryff_changeit = false; //bool que confirma si se cambiaron las cartas de Gryffindor
    public bool Slyth_changeit = false; //bool que confirma si se cambiaron las cartas de Slytherin
    public void cambioturno() //boton para cambiar de turno
    {
        
        if (GameManager.turn == "Gryff") //si el turno es de gryffindor
        {
            if (GameManager.ConfirmaTurno == false)
            {
                GameManager.Gryffindor = true;
            }
                GameManager.turn = "Slyth"; //cambia turno a slytherin
                GryffReverse.SetActive(true); //activa el reverso de las cartas
                SlythReverse.SetActive(false); //muestra el deck de slytherin
            if (Slyth_changeit == false) //si slytherin no ha cambiado las cartas
            {
                ChangeCards.GameObject.SetActive(true); //activa el boton
            }
            else
            {
                ChangeCards.GameObject.SetActive(false); //si las cambio, apaga el boton
            }
        }
        else
        {
            if (GameManager.ConfirmaTurno == false)
            {
                GameManager.Slytherin = true;
            }
            GameManager.turn = "Gryff";
            GryffReverse.SetActive(false);
            SlythReverse.SetActive(true);
            if (Gryff_changeit == false)
            {
                ChangeCards.GameObject.SetActive(true);
            }
            else
            {
                ChangeCards.GameObject.SetActive(false);
            }
        }
        GameManager.ConfirmaTurno = false; //permite que se pueda invocar una carta
    }
}
