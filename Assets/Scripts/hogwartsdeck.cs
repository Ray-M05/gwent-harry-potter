using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hogwartsdeck : MonoBehaviour
{
    public List<GameObject> Deck = new List<GameObject>();
    public List<RawImage> Pos = new List<RawImage>();
    public List<GameObject> Hand = new List<GameObject>();
    public List <TextMeshProUGUI> Points = new List<TextMeshProUGUI>();
    public List<RawImage> PosCuerpoacuerpo = new List<RawImage>();
    public List<RawImage> PosDistancia = new List<RawImage>();
    public List<RawImage> PosAsedio = new List<RawImage>();
    public List<RawImage> PosAumento = new List<RawImage>();
    public List<RawImage> PosClima = new List<RawImage>();
    public RawImage PosDespeje;
    public List<GameObject> Cementerio = new List<GameObject>();

    private void Start()
    {
        Deck = Shuffle();
        rob(10);
        muestracarta();    
    }
    private void Update()
    {
        verificards();
        muestracarta();
    }
    public void rob(int count)  //metodo de robar cartas del deck
    {
        for (int i = 0; (Hand.Count < 10)&& count>0; i++,count--) //mientras la mano tenga menos de 10 cartas y queden en el count 
        {
            Hand.Add(Deck[i]); //agrega las cartas de la mano al deck
            Deck.RemoveAt(i);
        }
        
    }

    public List<GameObject> Shuffle()
    {
        List<GameObject> list = new List<GameObject>(); //crea la lista para barajear
        int deckcount = Deck.Count; //crea la variable con la cantidad de elementos del deck
        while (deckcount != 0) //mientras que hayan elementos en el deck
        {
            int random = Random.Range(0, deckcount); //crea un numero random entre 0 y los elementos del deck
            list.Add(Deck[random]); //agrega a la lista el elemento del deck en la posicion random
            Deck.RemoveAt(random); //quita el indice random del deck
            deckcount--; //disminuye la cantidad de elementos del deck
        }

        return list; //devuelve la lista barajeada
    }

    public void muestracarta() //muestra las imagenes de las cartas en las imagenes en blanco de la mano
    {
        for (int i = 0; i < Pos.Count; i++)
        {
            Pos[i].GetComponent<RawImage>().texture = null; //se van a inicializar en null por cada update por si sufre cambios la mano
            Pos[i].GetComponent<RawImage>().texture = Hand[i].GetComponent<SpriteRenderer>().sprite.texture; //lleva la imagen de la carta de la mano a la posicion i en blanco del tablero
        }
    }


    public void verificards() //metodo que verifica si hay cartas en las posiciones
    {
        for (int i = 0; i < PosCuerpoacuerpo.Count; i++)  //recorre las imagenes en blanco que son posiciones cuerpoacuerpo
        {
            if (PosCuerpoacuerpo[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosCuerpoacuerpo[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosCuerpoacuerpo[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }

            if (PosDistancia[i].texture == null)  //recorre las imagenes en blanco que son posiciones distancia
            {
                PosDistancia[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                PosDistancia[i].transform.localScale = new Vector2(1, 1);
            }

            if (PosAsedio[i].texture == null) //recorre las imagenes en blanco que son posiciones asedio
            {
                PosAsedio[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                PosAsedio[i].transform.localScale = new Vector2(1, 1);
            }
        }

        for (int i = 0; i < PosAumento.Count; i++) //recorre las imagenes en blanco que son posiciones de la mano
        {
            if (PosAumento[i].texture == null)
            {
                PosAumento[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                PosAumento[i].transform.localScale = new Vector2(1, 1);
            }
        }

        for (int i = 0; i < PosClima.Count; i++) //recorre las imagenes en blanco que son posiciones de la mano
        {
            if (PosClima[i].texture == null)
            {
                PosClima[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                PosClima[i].transform.localScale = new Vector2(1, 1);
            }
        }

        for (int i = 0; i < Pos.Count; i++) //recorre las imagenes en blanco que son posiciones de la mano
        {
            if (Pos[i].texture == null)
            {
                Pos[i].transform.localScale = new Vector2(0, 0);
                Points[i].text = ""; //no recorre los puntos si no hay  una carta en la mano
            }
            else
            {
                Pos[i].transform.localScale = new Vector2(1, 1);
            }
        }

        if (PosDespeje.texture == null)
        {
            PosDespeje.transform.localScale = new Vector2(0, 0);
        }
        else
        {
            PosDespeje.transform.localScale = new Vector2(2, 2);
        }


    }
}