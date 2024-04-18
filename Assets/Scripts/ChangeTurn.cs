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


    public void cambioturno()
    {

        if (GameManager.turn == "Gryff") //si el turno es de gryffindor
        {
            if (GameManager.ConfirmaTurno == false)
            {
                GameManager.Gryffindor = true;
            }
                GameManager.turn = "Slyth"; //cambia turno a slytherin
                GryffReverse.SetActive(true);
                SlythReverse.SetActive(false);            
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
        }
        GameManager.ConfirmaTurno = false;
    }


}
