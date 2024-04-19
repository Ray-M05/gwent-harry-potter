using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    hogwartsdeck mazo;
    hogwartsdeck mazo1;
    public GameObject WinnerG;
    public GameObject WinnerS;

    public bool Gryffindor = false;
    public bool Slytherin = false;

    public List<Card> Points_Gryffindor_C = new List<Card>();
    public List<Card> Points_Gryffindor_D = new List<Card>();
    public List<Card> Points_Gryffindor_A = new List<Card>();
    public Card Points_Gryffindor_Aumento_C = null;
    public Card Points_Gryffindor_Aumento_D = null;
    public Card Points_Gryffindor_Aumento_A = null;


    public List<Card> Points_Slytherin_C = new List<Card>();
    public List<Card> Points_Slytherin_D = new List<Card>();
    public List<Card> Points_Slytherin_A = new List<Card>();
    public Card Points_Slytherin_Aumento_C = null;
    public Card Points_Slytherin_Aumento_D = null;
    public Card Points_Slytherin_Aumento_A = null;

    public Card Points_Clima_C = null;
    public Card Points_Clima_D = null;
    public Card Points_Clima_A = null;

    private void Start()
    {
        mazo = GameObject.FindGameObjectWithTag("Gryffindor").GetComponent<hogwartsdeck>(); //inicializa el mazo de gryffindor
        mazo1 = GameObject.FindGameObjectWithTag("Slytherin").GetComponent<hogwartsdeck>(); //inicializa el mazo de slytherin
        RoundsGryff.text = "0";
        RoundsSlyth.text = "0";
    }
    private void Update()
    {
        contador();
        new_round();
        winner();
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
        if (Points_Clima_C != null)
        {
            for (int i = 0; i < Points_Slytherin_C.Count; i++)
            {
                    if (Points_Slytherin_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB -= 3;
                    }
            }
            for (int i = 0; i < Points_Gryffindor_C.Count; i++)
            {
                    if (Points_Gryffindor_C[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 5; //los climas afectan a gryffindor mas por la habilidad de lider de slytherin
                    }
            }
        }
        if (Points_Clima_D != null)
        {
            for (int i = 0; i < Points_Slytherin_D.Count; i++)
            {
               if (Points_Slytherin_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                {
                        puntosB -= 3;
                }
            }
            for (int i = 0; i < Points_Gryffindor_D.Count; i++)
            {
                    if (Points_Gryffindor_D[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 5;
                    }
            }
        }
        if (Points_Clima_A != null)
        {
            for (int i = 0; i < Points_Slytherin_A.Count; i++)
            {
                    if (Points_Slytherin_A[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosB -= 3;
                    }
            }
            for (int i = 0; i < Points_Gryffindor_A.Count; i++)
            {
                    if (Points_Gryffindor_A[i].GetComponent<Card>().unidad != Kindofcard.Oro)
                    {
                        puntosA -= 5;
                    }
            }
        }
        PointsGryff.text = puntosA.ToString();
        PointsSlyth.text = puntosB.ToString();
    } 

    public void new_round()
    {
        if (Gryffindor == true && Slytherin ==true)
       {
            if (int.Parse(PointsGryff.text) >= int.Parse(PointsSlyth.text))
            {
            string text = RoundsGryff.text; 
               int pointA= int.Parse(text) ;
               pointA ++;
               RoundsGryff.text = pointA.ToString();
                //turn = "Slyth";
                
                //Gryffindor gana en caso de empate (habilidad del lider)
            }
            if (int.Parse(PointsGryff.text) < int.Parse(PointsSlyth.text))
            {
            string text = RoundsSlyth.text;
                int pointB = int.Parse(text);
                pointB++;
                RoundsSlyth.text = pointB.ToString();
                //turn = "Gryff";
            }
            PointsGryff.text = "0";
            PointsSlyth.text = "0";
            Points_Gryffindor_C.Clear();
            Points_Gryffindor_D.Clear();
            Points_Gryffindor_A.Clear();
            Points_Gryffindor_Aumento_A = null;
            Points_Gryffindor_Aumento_D = null;
            Points_Gryffindor_Aumento_C = null;


            Points_Slytherin_C.Clear();
            Points_Slytherin_D.Clear();
            Points_Slytherin_A.Clear();
            Points_Slytherin_Aumento_A = null;
            Points_Slytherin_Aumento_D = null;
            Points_Slytherin_Aumento_C = null;
            Points_Clima_A = null;
            Points_Clima_D = null;
            Points_Clima_C = null;
            end_round();
            Gryffindor = false;
            Slytherin = false;
            mazo.rob(2);
            mazo1.rob(2);
        }
    }

    public void end_round()

    {
        clean_scene(mazo);
        clean_scene(mazo1);
    }

    public void clean_scene(hogwartsdeck generica)
    {
        for (int i = 0; i < generica.PosCuerpoacuerpo.Count; i++)
        {
            generica.PosCuerpoacuerpo[i].texture = null;
            generica.PosDistancia[i].texture = null;
            generica.PosAsedio[i].texture = null;
        }
        for (int i = 0; i < generica.PosClima.Count; i++)
        {
            generica.PosClima[i].texture = null;
            generica.PosAumento[i].texture = null;
        }
        generica.PosDespeje.texture = null;
    }

    public void winner()
    {
        if (RoundsGryff.text == "2")
        {
            WinnerG.SetActive(true);
        }
        if (RoundsSlyth.text == "2")
        {
            WinnerS.SetActive(true);
        }
    }
}
