using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTurn : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject GryffReverse;
    public GameObject SlythReverse;

    
    public void cambioturno()
    {
        GameManager.ConfirmaTurno = false;
        
        if (GameManager.turn == "Gryff")
        {
            GameManager.turn = "Slyth";
            GryffReverse.SetActive(true);
            SlythReverse.SetActive(false);
        }
        else
        {
            GameManager.turn = "Gryff";
            GryffReverse.SetActive(false);
            SlythReverse.SetActive(true);
        }
    }
}
