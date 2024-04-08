using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ConfirmaTurno = false;
    public string turn;
    public TextMeshProUGUI PointsGryff;
    public TextMeshProUGUI PointsSlyth;

    public bool Gryffindor = false;
    public bool Slytherin = false;

    public List<Card> Points_Gryffindor_C = new List<Card>();
    public List<Card> Points_Gryffindor_D = new List<Card>();
    public List<Card> Points_Gryffindor_A = new List<Card>();
    public Card Points_Gryffindor_Aumento_C = null;
    public Card Points_Gryffindor_Aumento_D = null;
    public Card Points_Gryffindor_Aumento_A = null;
    public Card Points_Gryffindor_Clima_C = null;
    public Card Points_Gryffindor_Clima_D = null;
    public Card Points_Gryffindor_Clima_A = null;

    public List<Card> Points_Slytherin_C = new List<Card>();
    public List<Card> Points_Slytherin_D = new List<Card>();
    public List<Card> Points_Slytherin_A = new List<Card>();
    public Card Points_Slytherin_Aumento_C = null;
    public Card Points_Slytherin_Aumento_D = null;
    public Card Points_Slytherin_Aumento_A = null;
    public Card Points_Slytherin_Clima_C = null;
    public Card Points_Slytherin_Clima_D = null;
    public Card Points_Slytherin_Clima_A = null;

    private void Update()
    {
        contador();
    }
    public void contador()
    {
        int puntosA = 0;
        for (int i = 0; i < Points_Gryffindor_C.Count; i++)
        {
            if (Points_Gryffindor_C[i] != null)
            {
                puntosA += Points_Gryffindor_C[i].points;
            }
        }
        for (int i = 0; i < Points_Gryffindor_D.Count; i++)
        {
            if (Points_Gryffindor_D[i] != null)
            {
                puntosA += Points_Gryffindor_D[i].points;
            }
        }
        for (int i = 0; i < Points_Gryffindor_A.Count; i++)
        {
            if (Points_Gryffindor_A[i] != null)
            {
                puntosA += Points_Gryffindor_A[i].points;
            }
        }
        if (Points_Gryffindor_Aumento_C != null)
        {
            for (int i = 0; i < Points_Gryffindor_C.Count; i++)
            {
                if (Points_Gryffindor_C[i] != null)
                {
                    puntosA +=  2;
                }
            }
        }
        if (Points_Gryffindor_Aumento_D != null)
        {
            for (int i = 0; i < Points_Gryffindor_D.Count; i++)
            {
                if (Points_Gryffindor_D[i] != null)
                {
                    puntosA += 2;
                }
            }
        }
        if (Points_Gryffindor_Aumento_A != null)
        {
            for (int i = 0; i < Points_Gryffindor_A.Count; i++)
            {
                if (Points_Gryffindor_A[i] != null)
                {
                    puntosA += 2;
                }
            }
        }

        PointsGryff.text = puntosA.ToString();


        int puntosB = 0;
        for (int i = 0; i < Points_Slytherin_C.Count; i++)
        {
            if (Points_Slytherin_C[i] != null)
            {
                puntosB += Points_Slytherin_C[i].points;
            }
        }
        for (int i = 0; i < Points_Slytherin_D.Count; i++)
        {
            if (Points_Slytherin_D[i] != null)
            {
                puntosB += Points_Slytherin_D[i].points;
            }
        }
        for (int i = 0; i < Points_Slytherin_A.Count; i++)
        {
            if (Points_Slytherin_A[i] != null)
            {
                puntosB += Points_Slytherin_A[i].points;
            }
        }
        if (Points_Slytherin_Aumento_C != null)
        {
            for (int i = 0; i < Points_Slytherin_C.Count; i++)
            {
                if (Points_Slytherin_C[i] != null)
                {
                    puntosB += 2;
                }
            }
        }
        if (Points_Slytherin_Aumento_D != null)
        {
            for (int i = 0; i < Points_Slytherin_D.Count; i++)
            {
                if (Points_Slytherin_D[i] != null)
                {
                    puntosB += 2;
                }
            }
        }
        if (Points_Slytherin_Aumento_A != null)
        {
            for (int i = 0; i < Points_Slytherin_A.Count; i++)
            {
                if (Points_Slytherin_A[i] != null)
                {
                    puntosB += 2;
                }
            }
        }

        PointsSlyth.text = puntosB.ToString();
    } 
}
