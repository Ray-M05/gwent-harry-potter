using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cardaction : MonoBehaviour
{

    RawImage imagecard; //imagen de la carta actual
    hogwartsdeck mazo; //localizar el script deck
    hogwartsdeck mazo1;
    public GameObject panel_opciones,panel_invocaciones; //inicializar el panel de menu de invocaciones
    public int carta_mano;
    public string playerTurn;
    public RawImage cardvisual;
    public TextMeshProUGUI cardescription;
    public GameObject description_;
    
    private void Start()
    {
        imagecard = GetComponent<RawImage>(); //inicializa imagen de la carta
        mazo = GameObject.FindGameObjectWithTag("Gryffindor").GetComponent<hogwartsdeck>(); //inicializa el mazo de gryffindor
        mazo1 = GameObject.FindGameObjectWithTag("Slytherin").GetComponent<hogwartsdeck>(); //inicializa el mazo de slytherin
        cardvisual = GameObject.FindGameObjectWithTag("cardvisual").GetComponent<RawImage>();  //
        cardescription = GameObject.FindGameObjectWithTag("cardescription").GetComponent<TextMeshProUGUI>();

        cardvisual.transform.localScale = new Vector2(0, 0);
        description_.transform.localScale = new Vector2(0, 0);
    }

    public void Opciones()  //funcion del boton de carta
    {
        panel_opciones.SetActive(true);  //activa el panel de opciones cuando toca la carta
        panel_invocaciones.SetActive(false);
        panel_opciones.GetComponent<Buttonaction>().Carta = GetComponent<cardaction>();
        
        cardvisual.texture = imagecard.texture;  //le pasa la foto de la carta al cardvisual
        cardvisual.transform.localScale = new Vector2(1, 1);

        cardescription.text = "";
        description_.transform.localScale = new Vector2(1, 1);
        if (playerTurn == "Gryff")
        {
            for (int i = 0; i < mazo.Hand[carta_mano].GetComponent<Card>().campo.Length; i++)
            {
                cardescription.text += mazo.Hand[carta_mano].GetComponent<Card>().campo[i].ToString();
                cardescription.text += "\n";
            }
        }
        else if (playerTurn == "Slyth")
        {
            cardescription.text = "";
            for (int i = 0; i < mazo1.Hand[carta_mano].GetComponent<Card>().campo.Length; i++)
            {
                cardescription.text += mazo1.Hand[carta_mano].GetComponent<Card>().campo[i].ToString();
                cardescription.text += "\n";
            }
        }
    }
    public void invocar(int campo) //un numero que sera cuerpoacuerpo, distancia o asedio
    {
        if (playerTurn == "Gryff")
        {
            if (imagecard.texture != null) //verifica que haya una imagen en la carta
            {
                if (campocarta("Cuerpoacuerpo", mazo.Hand, carta_mano))
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

                if (campocarta("Asedio", mazo.Hand, carta_mano))
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

                if (campocarta("Aumento", mazo.Hand, carta_mano))
                {
                    if (campo == 7)
                    {
                        for (int i = 0; i < mazo.PosAumento.Count; i++) //recorre pos asedio
                        {
                            if (mazo.PosAumento[i].texture == null) //verifica que las pos asedio no tengan una carta
                            {
                                mazo.PosAumento[i].texture = imagecard.texture; //invocar la carta en asedio
                                imagecard.texture = null; //quita la carta de hand
                                break;
                            }
                        }
                    }
                }

                if (campocarta("Clima", mazo.Hand, carta_mano))
                {
                    for (int i = 0; i < mazo.PosClimaDespejeC.Count; i++)
                    {
                        if (campo == 4)
                        {
                            if (mazo.PosClimaDespejeC[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo.PosClimaDespejeC[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo1.PosClimaDespejeC[i].texture = imagecard.texture; //pasa el clima hacia la posicion del otro deck
                                imagecard.texture = null; //quita la carta de hand
                            }
                        }
                        if (campo == 5)
                        {
                            if (mazo.PosClimaDespejeD[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo.PosClimaDespejeD[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo1.PosClimaDespejeD[i].texture = imagecard.texture;
                                imagecard.texture = null; //quita la carta de hand
                            }
                        }
                        if (campo == 6)
                        {
                            if (mazo.PosClimaDespejeA[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo.PosClimaDespejeA[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo1.PosClimaDespejeA[i].texture = imagecard.texture;
                                imagecard.texture = null; //quita la carta de hand
                            }
                        }
                      
                    }
                }

            }
        }


        if (playerTurn == "Slyth")
        {
            if (imagecard.texture != null) //verifica que haya una imagen en la carta
            {
                if (campocarta("Cuerpoacuerpo", mazo1.Hand, carta_mano))
                {
                    if (campo == 1)
                    {
                        for (int i = 0; i < mazo1.PosCuerpoacuerpo.Count; i++) //recorre pos cuerpoacuerpo
                        {
                            if (mazo1.PosCuerpoacuerpo[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo1.PosCuerpoacuerpo[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                imagecard.texture = null; //quita la carta de hand
                                break;
                            }
                        }
                    }
                }

                if (campocarta("Distancia", mazo1.Hand, carta_mano))
                {
                    if (campo == 2)
                    {
                        for (int i = 0; i < mazo1.PosDistancia.Count; i++) //recorre pos distancia
                        {
                            if (mazo1.PosDistancia[i].texture == null) //verifica que las pos distancia no tengan una carta
                            {
                                mazo1.PosDistancia[i].texture = imagecard.texture; //invocar la carta en distancia
                                imagecard.texture = null; //quita la carta de hand
                                break;
                            }
                        }
                    }
                }

                if (campocarta("Asedio", mazo1.Hand, carta_mano))
                {
                    if (campo == 3)
                    {
                        for (int i = 0; i < mazo1.PosAsedio.Count; i++) //recorre pos asedio
                        {
                            if (mazo1.PosAsedio[i].texture == null) //verifica que las pos asedio no tengan una carta
                            {
                                mazo1.PosAsedio[i].texture = imagecard.texture; //invocar la carta en asedio
                                imagecard.texture = null; //quita la carta de hand
                                break;
                            }
                        }
                    }
                }

                if (campocarta("Aumento", mazo1.Hand, carta_mano))
                {
                    if (campo == 7)
                    {
                        for (int i = 0; i < mazo1.PosAumento.Count; i++) //recorre pos asedio
                        {
                            if (mazo1.PosAumento[i].texture == null) //verifica que las pos asedio no tengan una carta
                            {
                                mazo1.PosAumento[i].texture = imagecard.texture; //invocar la carta en asedio
                                imagecard.texture = null; //quita la carta de hand
                                break;
                            }
                        }
                    }
                }

                if (campocarta("Clima", mazo1.Hand, carta_mano))
                {
                    for (int i = 0; i < mazo1.PosClimaDespejeC.Count; i++)
                    {
                        if (campo == 4)
                        {
                            if (mazo1.PosClimaDespejeC[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo1.PosClimaDespejeC[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo.PosClimaDespejeC[i].texture = imagecard.texture;
                                imagecard.texture = null; //quita la carta de hand
                            }
                        }
                        if (campo == 5)
                        {
                            if (mazo1.PosClimaDespejeD[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo1.PosClimaDespejeD[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo.PosClimaDespejeD[i].texture = imagecard.texture;
                                imagecard.texture = null; //quita la carta de hand
                            }
                        }
                        if (campo == 6)
                        {
                            if (mazo1.PosClimaDespejeA[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                            {
                                mazo1.PosClimaDespejeA[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                mazo.PosClimaDespejeA[i].texture = imagecard.texture;
                                imagecard.texture = null; //quita la carta de hand
                            }
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
