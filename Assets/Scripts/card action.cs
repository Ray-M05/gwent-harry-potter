using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardaction : MonoBehaviour
{

    RawImage imagecard; //imagen de la carta actual
    hogwartsdeck mazo; //localizar el script deck
    public GameObject panel_opciones,panel_invocaciones; //inicializar el panel de menu de invocaciones
    public int carta_mano;
    public RawImage cardvisual;
    public TextMeshPro cardescription;
    private void Start()
    {
        imagecard = GetComponent<RawImage>(); //inicializa imagen de la carta
        mazo = GameObject.FindGameObjectWithTag("Gryffindor").GetComponent<hogwartsdeck>(); //inicializa el mazo
        cardvisual = GameObject.FindGameObjectWithTag("cardvisual").GetComponent<RawImage>();  //
        cardescription = GameObject.FindGameObjectWithTag("cardescription").GetComponent<TextMeshPro>();
    }

    public void Opciones()  //funcion del boton de carta
    {
        panel_opciones.SetActive(true);  //activa el panel de opciones cuando toca la carta
        panel_invocaciones.SetActive(false);
        panel_opciones.GetComponent<Buttonaction>().Carta = GetComponent<cardaction>();
        cardvisual.texture = imagecard.texture;
    }
    public void invocar(int campo) //un numero que sera cuerpoacuerpo, distancia o asedio
    {
        if (imagecard.texture != null) //verifica que haya una imagen en la carta
        {
            if(campocarta("Cuerpoacuerpo",mazo.Hand, carta_mano))
            {
                if (campo == 1)
                {
                    for (int i = 0; i < mazo.PosCuerpoacuerpo.Count; i++) //recorre pos cuerpoacuerpo
                    {
                        if (mazo.PosCuerpoacuerpo[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                        {
                            mazo.PosCuerpoacuerpo[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                            imagecard.texture = null; //quita la carta de hand
                            break;
                        }
                    }
                }
            }

            if (campocarta("Distancia", mazo.Hand, carta_mano))
            {
                if (campo == 2)
                {
                    for (int i = 0; i < mazo.PosDistancia.Count; i++) //recorre pos distancia
                    {
                        if (mazo.PosDistancia[i].texture == null) //verifica que las pos distancia no tengan una carta
                        {
                            mazo.PosDistancia[i].texture = imagecard.texture; //invocar la carta en distancia
                            imagecard.texture = null; //quita la carta de hand
                            break;
                        }
                    }
                }
            }

            if (campocarta("Asedio", mazo.Hand,carta_mano))
            {
                if (campo == 3)
                {
                    for (int i = 0; i < mazo.PosAsedio.Count; i++) //recorre pos asedio
                    {
                        if (mazo.PosAsedio[i].texture == null) //verifica que las pos asedio no tengan una carta
                        {
                            mazo.PosAsedio[i].texture = imagecard.texture; //invocar la carta en asedio
                            imagecard.texture = null; //quita la carta de hand
                            break;
                        }
                    }
                }
            }
                
            
        }
    }
    public bool campocarta(string verificacion, List<GameObject> hand,int carta_a_revisar)
    {
        for(int i = 0; i < hand[carta_a_revisar].GetComponent<Card>().campo.Length;i++)
        {
            if (hand[carta_a_revisar].GetComponent<Card>().campo[i].ToString() == verificacion)
            {
                return true;
            }
        }
        
        return false;
    }
}
