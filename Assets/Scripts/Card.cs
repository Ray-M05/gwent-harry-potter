using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public int points;
    public Leaderfaction house;
    public Kindofcard unidad;
    public Place[] campo;
    public new string name;
    
}
 
 public enum Leaderfaction{
        Gryffindor,
        Slytherin,
    }

public enum Kindofcard{
        Oro,
        Plata,
        Clima,
        Aumento,
        Despeje,
        Señuelo,
    }

public enum Place{
        Cuerpoacuerpo,
        Asedio,
        Distancia,
        Clima,
        Aumento,
        Despeje,
        Señuelo,
        Cementerio,
    }

    


    /*public Card(string name, int points, Leaderfaction house, Kindofcard unidad, Place[] campo){
        this.name = name;
        this.points = points;
        this.house = house;
        this.unidad = unidad;
        this.campo = campo;
    }*/
