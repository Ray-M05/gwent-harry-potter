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
    public Superpower hability;
    public string description_skills;
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
        Senuelo,
    }

public enum Place{
        Cuerpoacuerpo,
        Asedio,
        Distancia,
        Clima,
        Aumento,
        Despeje,
        Cementerio,
        Senuelo,
    }

public enum Superpower
{
    add_aumento,
    add_clima,
    clean_card_up,
    rob_,
    clean_j_down,
    own,
    none,
}

/*
 description skills:

add_aumento: agrega una unidad de aumento a la fila de la carta que posee la habilidad
add_clima: agrega una unidad de clima a la fila de la carta que posee la habilidad
clean_card_up: elimina la carta con mayor poder del campo del rival
rob_: roba una carta
clean_j_down: limpia la fila con mas unidades del rival
clima: afectan la fila seleccionada disminuyendo en 3 el poder de cada carta en ambos campos
aumento: bonifican la fila seleccionada aumentando en 2 el poder de cada carta en el campo propio
despeje: elimina todas las unidades de clima del campo
señuelo: coloca una carta con poder 0 en el lugar de la carta con mayor poder de la fila seleccionada y regresa a la mano
unidad_oro: No es faectada por ninguna habilidad especial
 */
