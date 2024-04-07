using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hogwartsdeck : MonoBehaviour
{
    public List<GameObject> Deck = new List<GameObject>();
    public List<RawImage> Pos = new List<RawImage>();
    public List<GameObject> Hand = new List<GameObject>();
    public List<RawImage> PosCuerpoacuerpo = new List<RawImage>();
    public List<RawImage> PosDistancia = new List<RawImage>();
    public List<RawImage> PosAsedio = new List<RawImage>();
    public List<RawImage> PosClimaDespejeC = new List<RawImage>();
    public List<RawImage> PosClimaDespejeD = new List<RawImage>();
    public List<RawImage> PosClimaDespejeA = new List<RawImage>();
    public List<RawImage> PosAumentoC = new List<RawImage>();
    public List<RawImage> PosAumentoD = new List<RawImage>();
    public List<RawImage> PosAumentoA = new List<RawImage>();
    public List<RawImage> PosDespeje = new List<RawImage>();
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
    }
    public void rob(int count)  //metodo de robar cartas del deck
    {
        for (int i = 0; i < count; i++) //va a recorrer el numero de cartas que se robaran 
        {
            Hand.Add(Deck[i]); //agrega las cartas de la mano al deck
        }
        for (int i = 0; i < count; i++)
        {
            Deck.RemoveAt(0); //remueve esa misma carta del deck
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

        return list; 
    }

    public void muestracarta() //muestra las imagenes de las cartas en las imagenes en blanco de la mano
    {
        for (int i = 0; i < Pos.Count; i++)
        {
            //lleva la imagen de la carta de la mano a la posicion i en blanco del tablero
            Pos[i].GetComponent<RawImage>().texture = Hand[i].GetComponent<SpriteRenderer>().sprite.texture; 
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

        for (int i = 0; i < PosClimaDespejeC.Count; i++) 
        {
            if (PosClimaDespejeC[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosClimaDespejeC[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosClimaDespejeC[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }

            if (PosClimaDespejeA[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosClimaDespejeA[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosClimaDespejeA[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }

            if (PosClimaDespejeD[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosClimaDespejeD[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosClimaDespejeD[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }
        }

        for (int i = 0; i < PosAumentoC.Count; i++)
        {
            if (PosAumentoC[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosAumentoC[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosAumentoC[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }

            if (PosAumentoA[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosAumentoA[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosAumentoA[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }

            if (PosAumentoD[i].texture == null) //si no hay imagen de una carta en la posicion
            {
                PosAumentoD[i].transform.localScale = new Vector2(0, 0); // la escla x y y seran 0
            }
            else
            {
                PosAumentoD[i].transform.localScale = new Vector2(1, 1); // la escala sera 1,1 (dimension de la carta en pos)
            }
        }

        for (int i = 0; i < PosDespeje.Count; i++) //recorre las imagenes en blanco que son posiciones de la mano
        {
            if (PosDespeje[i].texture == null)
            {
                PosDespeje[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                PosDespeje[i].transform.localScale = new Vector2(1, 1);
            }
        }

        for (int i = 0; i < Pos.Count; i++) //recorre las imagenes en blanco que son posiciones de la mano
        {
            if (Pos[i].texture == null)
            {
                Pos[i].transform.localScale = new Vector2(0, 0);
            }
            else
            {
                Pos[i].transform.localScale = new Vector2(1, 1);
            }
        }

       
    }
}