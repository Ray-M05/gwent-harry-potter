using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public bool ConfirmaTurno = false;
    public string turn; // Gryff o Slyth
    public TextMeshProUGUI PointsGryff; //puntos de las cartas de la mano de Gryffindor
    public TextMeshProUGUI PointsSlyth;//puntos de las cartas de la mano de Slytherin
    public TextMeshProUGUI RoundsGryff; //rondas ganadas de Gryff
    public TextMeshProUGUI RoundsSlyth;//rondas ganadas de Slyth
    public cardaction cardaction;
    public hogwartsdeck hogwartsdeck;
    hogwartsdeck mazo; //mazo de Gryffindor
    hogwartsdeck mazo1; //mazo de slytherin
    public GameObject WinnerG; //imagen de ganador de Gryffindor
    public GameObject WinnerS; //imagen de ganador de Slytherin
    public GameObject change_cards; //boton de cambiar cartas

    public bool Gryffindor = false; //bool que comprueba si gryffindor paso el turno sin jugar
    public bool Slytherin = false;  //bool que comprueba si slytherin paso el turno sin jugar

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
        mazo = GameObject.FindGameObjectWithTag("Gryffindor").GetComponent<hogwartsdeck>(); //inicializa el objeto que posee el tag
        mazo1 = GameObject.FindGameObjectWithTag("Slytherin").GetComponent<hogwartsdeck>(); 
        change_cards = GameObject.FindGameObjectWithTag("change").GetComponent<GameObject>();
        RoundsGryff.text = "0";
        RoundsSlyth.text = "0";
    }
    private void Update()
    {
        contador();
        new_round();
        winner();
    }
    public void contador() //recorre cada lista o carta de puntos y va sumando su propiedad al TMP que le corresponde a cada jugador
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
                        puntosB += 2; //suma los puntos de cada carta diferente a las de oro
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
                    if (Points_Slytherin_C[i].GetComponent<Card>().unidad != Kindofcard.Oro) //no cuenta las cartas de tipo oro ya que no les afecta
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
        if (Gryffindor == true && Slytherin ==true) //si ambos jugadores pasaron de turno sin jugar 
       {
            if (int.Parse(PointsGryff.text) >= int.Parse(PointsSlyth.text)) //compara las puntuaciones de los jugadores 
            {
            string text = RoundsGryff.text; 
               int pointA= int.Parse(text); 
               pointA ++;
               RoundsGryff.text = pointA.ToString();
               //Gryffindor gana en caso de empate (habilidad del lider)
            }
            if (int.Parse(PointsGryff.text) < int.Parse(PointsSlyth.text))
            {
            string text = RoundsSlyth.text;
                int pointB = int.Parse(text);
                pointB++;
                RoundsSlyth.text = pointB.ToString();
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

            end_round(); //limpia los campos
            Gryffindor = false; //permite que vuelvan a jugar accediendo al panel de invocaciones despues de pasarse
            Slytherin = false;
            mazo.rob(2); //roban 2 cartas al comenzar la ronda
            mazo1.rob(2);
        }
    }

    public void end_round()

    {
        clean_scene(mazo);
        clean_scene(mazo1);
    }

    public void clean_scene(hogwartsdeck generica) //limpia todo el campo perteneciente a un mazo determinado y los puntos de estos
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

    public void winner() //si algun contador de rondas ganadas llega a 2 entonces activa la imagen de ganador respectiva
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

    public int mayor_carta (List<Card> lista) //funcion que devuelve el indice de la carta con mayor poder de las listas de puntos
    {

        int mayor = 0;
        int posicion = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].unidad != Kindofcard.Oro) //evita tomar las cartas de oro
                {
                    if (lista[i].points > mayor)
                    {
                        mayor = lista[i].points;
                        posicion = i;
                    }
                return posicion;
                }
            }
        return -1; //si la primera posicion es de oro evita tomar el primer indice de la lista, devolviendo un indice inexistente
    }

    public List<Card> Puntos_asociados(List<RawImage> lista) //funcion que devuelve la lista de puntos asociadas a una fila determinada del campo
    {
        if (lista == mazo.PosCuerpoacuerpo)
        {
            return Points_Gryffindor_C;
        }
        if (lista == mazo.PosDistancia)
        {
            return Points_Gryffindor_D;
        }
        if (lista == mazo.PosAsedio)
        {
            return Points_Gryffindor_A;
        }
        if (lista == mazo1.PosCuerpoacuerpo)
        {
            return Points_Slytherin_C;
        }
        if (lista == mazo1.PosDistancia)
        {
            return Points_Slytherin_D;
        }
        if (lista == mazo1.PosAsedio)
        {
            return Points_Slytherin_A;
        }
        return null;
    } 
}
