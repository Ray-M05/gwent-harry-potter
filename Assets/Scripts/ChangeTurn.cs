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

        if (GameManager.turn == "Gryff")
        {
            if (GameManager.ConfirmaTurno == false)
            {
                GameManager.Gryffindor = true;
            }
                GameManager.turn = "Slyth";
                GryffReverse.SetActive(true);
                //HandG.SetActive(false);
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
            //HandS.SetActive(false);
        }
        GameManager.ConfirmaTurno = false;
    }


}
