using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public bool ConfirmaTurno = false;
    public string turn;
    public TextMeshProUGUI PointsGryff;
    public TextMeshProUGUI PointsSlyth;
    public TextMeshProUGUI RoundsGryff;
    public TextMeshProUGUI RoundsSlyth;
    public cardaction cardaction;
    public hogwartsdeck hogwartsdeck;

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
        new_round();
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
                    if (Points_Gryffindor_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA += 2;
                    }
                }
            }
        }
        if (Points_Gryffindor_Aumento_D != null)
        {
            for (int i = 0; i < Points_Gryffindor_D.Count; i++)
            {
                if (Points_Gryffindor_D[i] != null)
                {
                    if (Points_Gryffindor_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA += 2;
                    }
                }
            }
        }
        if (Points_Gryffindor_Aumento_A != null)
        {
            for (int i = 0; i < Points_Gryffindor_A.Count; i++)
            {
                if (Points_Gryffindor_A[i] != null)
                {
                    if (Points_Gryffindor_A[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA += 2;
                    }
                }
            }
        }
        if (Points_Gryffindor_Clima_C != null)
        {
            for (int i = 0; i < Points_Gryffindor_C.Count; i++)
            {
                if (Points_Gryffindor_C[i] != null)
                {
                    if (Points_Gryffindor_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 3;
                    }
                }
            }
        }
        if (Points_Gryffindor_Clima_D != null)
        {
            for (int i = 0; i < Points_Gryffindor_D.Count; i++)
            {
                if (Points_Gryffindor_D[i] != null)
                {
                    if (Points_Gryffindor_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 3;
                    }
                }
            }
        }
        if (Points_Gryffindor_Clima_A != null)
        {
            for (int i = 0; i < Points_Gryffindor_A.Count; i++)
            {
                if (Points_Gryffindor_A[i] != null)
                {
                    if (Points_Gryffindor_A[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 3;
                    }
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
                    if (Points_Slytherin_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB += 2;
                    }
                }
            }
        }
        if (Points_Slytherin_Aumento_D != null)
        {
            for (int i = 0; i < Points_Slytherin_D.Count; i++)
            {
                if (Points_Slytherin_D[i] != null)
                {
                    if (Points_Slytherin_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB += 2;
                    }
                }
            }
        }
        if (Points_Slytherin_Aumento_A != null)
        {
            for (int i = 0; i < Points_Slytherin_A.Count; i++)
            {
                if (Points_Slytherin_A[i] != null)
                {
                    if (Points_Slytherin_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB += 2;
                    }
                }
            }
        }
        if (Points_Slytherin_Clima_C != null)
        {
            for (int i = 0; i < Points_Slytherin_C.Count; i++)
            {
                if (Points_Slytherin_C[i] != null)
                {
                    if (Points_Slytherin_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB -= 3;
                    }
                }
            }
        }
        if (Points_Slytherin_Clima_D != null)
        {
            for (int i = 0; i < Points_Slytherin_D.Count; i++)
            {
                if (Points_Slytherin_D[i] != null)
                {
                    if (Points_Slytherin_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB -= 3;
                    }
                }
            }
        }
        if (Points_Slytherin_Clima_A != null)
        {
            for (int i = 0; i < Points_Slytherin_A.Count; i++)
            {
                if (Points_Slytherin_A[i] != null)
                {
                    if (Points_Slytherin_A[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB -= 3;
                    }
                }
            }
        }

        PointsSlyth.text = puntosB.ToString();
    } 

    public void new_round()
    {
        RoundsGryff.text = "0";
        RoundsSlyth.text = "0";
        if (Gryffindor == true && Slytherin ==true)
       {
            if (int.Parse(PointsGryff.text) >= int.Parse(PointsSlyth.text))
            {
            string text = RoundsGryff.text; 
               int pointA= int.Parse(text) ;
               pointA ++;
               RoundsGryff.text = pointA.ToString();
                turn = "Gryff";
            }
            else
            {
            string text = RoundsGryff.text;
                int pointB = int.Parse(text);
                pointB++;
                RoundsSlyth.text = pointB.ToString();
                turn = "Slyth";
            }
            PointsGryff.text = "0";
            PointsSlyth.text = "0";
            cardaction.end_round();
            Points_Gryffindor_C.Clear();
            Points_Gryffindor_D.Clear();
            Points_Gryffindor_A.Clear();
            Points_Gryffindor_Aumento_A = null;
            Points_Gryffindor_Aumento_D = null;
            Points_Gryffindor_Aumento_C = null;
            Points_Gryffindor_Clima_A = null;
            Points_Gryffindor_Clima_D = null;
            Points_Gryffindor_Clima_C = null;

            Points_Slytherin_C.Clear();
            Points_Slytherin_D.Clear();
            Points_Slytherin_A.Clear();
            Points_Slytherin_Aumento_A = null;
            Points_Slytherin_Aumento_D = null;
            Points_Slytherin_Aumento_C = null;
            Points_Slytherin_Clima_A = null;
            Points_Slytherin_Clima_D = null;
            Points_Slytherin_Clima_C = null;
            cardaction.end_round();
        }
       
        

    }

    
}
