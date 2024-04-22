using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using System;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class cardaction : MonoBehaviour
{

    RawImage imagecard; //imagen de la carta actual
    hogwartsdeck mazo; //localizar el deck
    hogwartsdeck mazo1;
    public GameObject panel_opciones,panel_invocaciones; //inicializar el panel de menu de invocaciones
    public int carta_mano;
    public string playerTurn;
    public RawImage cardvisual;
    public TextMeshProUGUI cardescription;
    public GameObject description_;
    public GameManager GameManager;
    public hogwartsdeck hogwartsdeck;
    public TextMeshProUGUI hability;
    public Card Leader1;
    public Card Leader2;

    
    private void Start()
    {
        imagecard = GetComponent<RawImage>(); //inicializa imagen de la carta
        mazo = GameObject.FindGameObjectWithTag("Gryffindor").GetComponent<hogwartsdeck>(); //inicializa el mazo de gryffindor
        mazo1 = GameObject.FindGameObjectWithTag("Slytherin").GetComponent<hogwartsdeck>(); //inicializa el mazo de slytherin
        cardvisual = GameObject.FindGameObjectWithTag("cardvisual").GetComponent<RawImage>();  
        cardescription = GameObject.FindGameObjectWithTag("cardescription").GetComponent<TextMeshProUGUI>();
        hability = GameObject.FindGameObjectWithTag("Hability").GetComponent<TextMeshProUGUI>();
        Leader1 = GameObject.FindGameObjectWithTag("Harry").GetComponent<Card>(); //inicializa el primer lider a partir de su tag
        Leader2 = GameObject.FindGameObjectWithTag("Voldemort").GetComponent<Card>();


        cardvisual.transform.localScale = new Vector2(0, 0); //el visual y la descripcion se inicializan en escala 0
        description_.transform.localScale = new Vector2(0, 0);
    }

    private void Update()
    {
        muestrapuntos();   
    }

    public void Opciones()  //funcion del boton de carta
    {
        if(playerTurn == GameManager.turn) //cuando el turno le corresponda al player
        {
            panel_opciones.SetActive(true);  //activa el panel de opciones cuando toca la carta
            panel_invocaciones.SetActive(false);
            panel_opciones.GetComponent<Buttonaction>().Carta = GetComponent<cardaction>(); 

            cardvisual.texture = imagecard.texture;  //le pasa la foto de la carta al cardvisual
            cardvisual.transform.localScale = new Vector2(1, 1); //aumenta su escala

            cardescription.text = "";
            description_.transform.localScale = new Vector2(1, 1);

            if (playerTurn == "Gryff")
            {
                for (int i = 0; i < mazo.Hand[carta_mano].GetComponent<Card>().campo.Length; i++) //recorre las propiedades de campo de las cartas de la mano
                {
                    cardescription.text += mazo.Hand[carta_mano].GetComponent<Card>().campo[i].ToString(); //la pos de carta_mano le pasa las propiedades de campo de su carta
                    cardescription.text += "\n"; //separa las lineas
                    hability.text = mazo.Hand[carta_mano].GetComponent<Card>().description_skills; //le pasa la habilidad al texto 
                }
            }
            else if (playerTurn == "Slyth")
            {
                cardescription.text = "";
                for (int i = 0; i < mazo1.Hand[carta_mano].GetComponent<Card>().campo.Length; i++)
                {
                    cardescription.text += mazo1.Hand[carta_mano].GetComponent<Card>().campo[i].ToString();
                    cardescription.text += "\n";
                    hability.text = mazo1.Hand[carta_mano].GetComponent<Card>().description_skills;
                }
            }
        }
        
    }

    public void leader1() //le pasa la habilidad de lider a la descripcion
    {
        hability.text = Leader1.description_skills.ToString(); 
    } 
    public void leader2() { 
        hability.text = Leader2.description_skills.ToString();
    }

    public void muestrapuntos()
    {
        if (GameManager.turn == "Gryff") //si el turno es de Gryffindor
        {
            for (int j = 0; j < mazo.Points.Count; j++) //por cada TMP de la lista puntos 
            {
                mazo.Points[j].text = mazo.Hand[j].GetComponent<Card>().points.ToString(); //le pasa el poder de las cartas de la mano al texto
                mazo1.Points[j].text = null; //los inicializa en null desde el otro deck para que no sean visibles
            }
        }
        else if (GameManager.turn == "Slyth")
        {
            for (int j = 0; j < mazo1.Points.Count; j++)
            {
                mazo1.Points[j].text = mazo1.Hand[j].GetComponent<Card>().points.ToString();
                mazo.Points[j].text = null;
            }
        }
    }
    public void invocar(int campo) //un numero que sera cuerpoacuerpo, distancia o asedio
    {
        if(!GameManager.ConfirmaTurno) //si no se ha confirmado que ya jugo o comienza el turno 
        {
            if (playerTurn == "Gryff" && GameManager.turn == playerTurn) 
            {
                if (GameManager.Gryffindor == false) //si no paso el turno sin jugar
                {
                    if (imagecard.texture != null) //verifica que haya una imagen en la carta
                    {
                        if (campocarta("Cuerpoacuerpo", mazo.Hand, carta_mano)) //comprueba si la carta le correponde la propiedad de campo en la que se esta invocando
                        {
                            if (campo == 1) //comprueba si se toco el boton correspondiente a ese campo
                            {
                                for (int i = 0; i < mazo.PosCuerpoacuerpo.Count; i++) //recorre pos cuerpoacuerpo
                                {
                                    if (mazo.PosCuerpoacuerpo[i].texture == null) //verifica que las pos cuerpoacuerpo no tengan una carta
                                    {
                                        mazo.PosCuerpoacuerpo[i].texture = imagecard.texture; //pasa la imagen de la carta en pos cuerpoacuerpo
                                        GameManager.ConfirmaTurno = true;  //confirma que ya se invoco una carta y no puede seguir jugando                                 

                                        searching_effect(mazo.Hand[carta_mano].GetComponent<Card>(), mazo.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo, mazo1, mazo.PosCuerpoacuerpo, mazo1.PosCuerpoacuerpo); //comprueba si la carta tenia efecto
                                        GameManager.Points_Gryffindor_C.Add(mazo.Hand[carta_mano].GetComponent<Card>()); //agrega la carta invocada a la lista de puntos que le corresponde
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo.Cementerio.Add(mazo.Hand[carta_mano]); //agrega la carta al cementerio como objeto
                                        mazo.Hand.RemoveAt(carta_mano); //remueve la carta del hand
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
                                        GameManager.ConfirmaTurno = true;

                                        searching_effect(mazo.Hand[carta_mano].GetComponent<Card>(), mazo.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo, mazo1, mazo.PosDistancia, mazo1.PosDistancia);
                                        GameManager.Points_Gryffindor_D.Add(mazo.Hand[carta_mano].GetComponent<Card>());
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                        mazo.Hand.RemoveAt(carta_mano);
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
                                        GameManager.ConfirmaTurno = true;                                     

                                        searching_effect(mazo.Hand[carta_mano].GetComponent<Card>(), mazo.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo, mazo1, mazo.PosAsedio, mazo1.PosAsedio);
                                        GameManager.Points_Gryffindor_A.Add(mazo.Hand[carta_mano].GetComponent<Card>());
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                        mazo.Hand.RemoveAt(carta_mano);
                                        break;
                                    }
                                }
                            }
                        }

                        if (campocarta("Aumento", mazo.Hand, carta_mano))
                        {
                            if (campo == 4) //aumento en pos cuerpo a cuerpo
                            {
                                if (mazo.PosAumento[0].texture == null) //comprueba si en la primera pos de la lisat de aumento no hay una cart
                                {
                                    mazo.PosAumento[0].texture = imagecard.texture; //le pasa la textura a la pos que le corresponde
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true; //confirma que ya se jugo una carta
                                    GameManager.Points_Gryffindor_Aumento_C = mazo.Hand[carta_mano].GetComponent<Card>(); //pasa la carta como objeto a la lista de puntos
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]); //lleva la carta invocada al cementerio
                                    mazo.Hand.RemoveAt(carta_mano); //quita la carta de la mano
                                }
                            }
                            if (campo == 5)
                            {
                                if (mazo.PosAumento[1].texture == null)
                                {
                                    mazo.PosAumento[1].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Gryffindor_Aumento_D = mazo.Hand[carta_mano].GetComponent<Card>();
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                    mazo.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 6)
                            {
                                if (mazo.PosAumento[2].texture == null)
                                {
                                    mazo.PosAumento[2].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Gryffindor_Aumento_A = mazo.Hand[carta_mano].GetComponent<Card>();
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                    mazo.Hand.RemoveAt(carta_mano);
                                }
                            }
                        }

                        if (campocarta("Clima", mazo.Hand, carta_mano))
                        {
                            if (campo == 7)
                            {
                                if (mazo.PosClima[0].texture == null)
                                {
                                    mazo.PosClima[0].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_C = mazo.Hand[carta_mano].GetComponent<Card>();
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                    mazo.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 8)
                            {
                                if (mazo.PosClima[1].texture == null)
                                {
                                    mazo.PosClima[1].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_D = mazo.Hand[carta_mano].GetComponent<Card>();
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                    mazo.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 9)
                            {
                                if (mazo.PosClima[2].texture == null)
                                {
                                    mazo.PosClima[2].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_A = mazo.Hand[carta_mano].GetComponent<Card>();
                                    mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                    mazo.Hand.RemoveAt(carta_mano);
                                }
                            }
                        }

                        if (campocarta("Despeje", mazo.Hand, carta_mano))
                        {
                            if (campo == 10)
                            {
                                for (int i = 0; i < mazo.PosClima.Count; i++)
                                {
                                        mazo.PosClima[i].texture = null; //elimina todas las texturas de las pos de clima
                                        GameManager.ConfirmaTurno = true; //confirma que se jugo una carta
                                        GameManager.Points_Clima_A = null; //elimina las cartas de clima de los contadores de puntos
                                        GameManager.Points_Clima_D = null;
                                        GameManager.Points_Clima_C = null;
                                }
                                mazo.PosDespeje.texture = imagecard.texture; //no es necesario comprobar si no hay una carta pues se pueden invocar siempre que se quiera y realiza el mismo efecto
                                imagecard.texture = null;
                                mazo.Cementerio.Add(mazo.Hand[carta_mano]);
                                mazo.Hand.RemoveAt(carta_mano);
                            }
                        }
                        if (campocarta("Senuelo", mazo.Hand, carta_mano))
                        {
                            if (campo == 11) //boton al que le corrsponde cuerpo a cuerpo
                            {
                                int A = GameManager.mayor_carta(GameManager.Points_Gryffindor_C); //busca la carta con mayor poder de la posicion en que fue invocada
                                string name = GameManager.Points_Gryffindor_C[A].name; //variable que va a tener la propiedad nombre de la mayor carta
                                
                                for (int i = 0; i < mazo.PosCuerpoacuerpo.Count; i++)
                                {
                                    if (GameManager.Points_Gryffindor_C[A].GetComponent<SpriteRenderer>().sprite.texture == mazo.PosCuerpoacuerpo[i].texture) //comprueba si existe alguna carta que tenga la misma imagen de la mayor
                                    {
                                        mazo.PosCuerpoacuerpo[i].texture = imagecard.texture; //intercambia la imagen por la del senuelo
                                        break; //sale del ciclo para evitar que tome dos o mas cartas en caso de estar repetida
                                    }
                                }
                                for (int j = 0; j < mazo.Cementerio.Count; j++) //recorre las cartas del cementerio del mazo
                                {
                                    if (mazo.Cementerio[j].GetComponent<Card>().name == name) //verifica si hay alguna carta con el nombre de la mayor
                                    {
                                        mazo.Hand.RemoveAt(carta_mano); //quita la carta de senuelo del hand
                                        mazo.Hand.Add(mazo.Cementerio[j]); //agrega al hand la carta mayor desde el cementerio
                                        break; //sale del ciclo para tomar solo una en caso de estar repetida
                                    }
                                }
                                GameManager.Points_Gryffindor_C.RemoveAt(A); //elimina la carta de la lista de puntos que le corresponde
                                GameManager.ConfirmaTurno = true; //confirma que se jugo una carta
                            }
                            if (campo == 12)
                            {
                                int A = GameManager.mayor_carta(GameManager.Points_Gryffindor_D);
                                string name = GameManager.Points_Gryffindor_D[A].name;

                                for (int i = 0; i < mazo.PosDistancia.Count; i++)
                                {
                                    if (GameManager.Points_Gryffindor_D[A].GetComponent<SpriteRenderer>().sprite.texture == mazo.PosDistancia[i].texture)
                                    {
                                        mazo.PosDistancia[i].texture = imagecard.texture;
                                        break;
                                    }
                                }
                                for (int j = 0; j < mazo.Cementerio.Count; j++)
                                {
                                    if (mazo.Cementerio[j].GetComponent<Card>().name == name)
                                    {
                                        mazo.Hand.RemoveAt(carta_mano);
                                        mazo.Hand.Add(mazo.Cementerio[j]);
                                        break;
                                    }
                                }
                                GameManager.Points_Gryffindor_D.RemoveAt(A);
                                GameManager.ConfirmaTurno = true;
                            }
                            if (campo == 13)
                                {
                                 int A = GameManager.mayor_carta(GameManager.Points_Gryffindor_A);
                                 string name = GameManager.Points_Gryffindor_A[A].name;

                                 for (int i = 0; i < mazo.PosAsedio.Count; i++)
                                    {
                                    if (GameManager.Points_Gryffindor_A[A].GetComponent<SpriteRenderer>().sprite.texture == mazo.PosAsedio[i].texture)
                                    {
                                      mazo.PosAsedio[i].texture = imagecard.texture;
                                        break;
                                    }
                                 }
                                 for (int j = 0; j < mazo.Cementerio.Count; j++)
                                 {
                                    if (mazo.Cementerio[j].GetComponent<Card>().name == name)
                                    {
                                        mazo.Hand.RemoveAt(carta_mano);
                                        mazo.Hand.Add(mazo.Cementerio[j]);
                                        break;
                                    }
                                 }
                              GameManager.Points_Gryffindor_A.RemoveAt(A);
                              GameManager.ConfirmaTurno = true;
                            }
                        }
                    }
                }
            }
            


            if (playerTurn == "Slyth" && GameManager.turn == playerTurn) //analogamente para el turno de Slytherin
            {
                if (GameManager.Slytherin == false)
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
                                        GameManager.ConfirmaTurno = true;                                    

                                        searching_effect(mazo1.Hand[carta_mano].GetComponent<Card>(), mazo1.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo1, mazo, mazo1.PosCuerpoacuerpo, mazo.PosCuerpoacuerpo);
                                        GameManager.Points_Slytherin_C.Add(mazo1.Hand[carta_mano].GetComponent<Card>());
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                        mazo1.Hand.RemoveAt(carta_mano);
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
                                        GameManager.ConfirmaTurno = true;

                                        searching_effect(mazo1.Hand[carta_mano].GetComponent<Card>(), mazo1.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo1, mazo, mazo1.PosDistancia, mazo.PosDistancia);
                                        GameManager.Points_Slytherin_D.Add(mazo1.Hand[carta_mano].GetComponent<Card>());
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                        mazo1.Hand.RemoveAt(carta_mano);
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
                                        GameManager.ConfirmaTurno = true;                     

                                        searching_effect(mazo1.Hand[carta_mano].GetComponent<Card>(), mazo1.Hand[carta_mano].GetComponent<Card>().hability.ToString(), mazo1, mazo, mazo1.PosAsedio, mazo.PosAsedio);
                                        GameManager.Points_Slytherin_A.Add(mazo1.Hand[carta_mano].GetComponent<Card>());
                                        imagecard.texture = null; //quita la carta de hand
                                        mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                        mazo1.Hand.RemoveAt(carta_mano);
                                        break;
                                    }
                                }
                            }
                        }

                        if (campocarta("Aumento", mazo1.Hand, carta_mano))
                        {
                            if (campo == 4)
                            {
                                if (mazo1.PosAumento[0].texture == null)
                                {
                                    mazo1.PosAumento[0].texture = imagecard.texture;
                                    imagecard.texture = null;
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Slytherin_Aumento_C = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 5)
                            {
                                if (mazo1.PosAumento[1].texture == null)
                                {
                                    mazo1.PosAumento[1].texture = imagecard.texture;
                                    imagecard.texture = null;
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Slytherin_Aumento_D = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 6)
                            {
                                if (mazo1.PosAumento[2].texture == null)
                                {
                                    mazo1.PosAumento[2].texture = imagecard.texture;
                                    imagecard.texture = null;
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Slytherin_Aumento_A = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                        }

                        if (campocarta("Clima", mazo1.Hand, carta_mano))
                        {
                            if (campo == 7)
                            {
                                if (mazo1.PosClima[0].texture == null)
                                {
                                    mazo1.PosClima[0].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_C = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 8)
                            {
                                if (mazo1.PosClima[1].texture == null)
                                {
                                    mazo1.PosClima[1].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_D = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                            if (campo == 9)
                            {
                                if (mazo1.PosClima[2].texture == null)
                                {
                                    mazo1.PosClima[2].texture = imagecard.texture;
                                    imagecard.texture = null; //quita la carta de hand
                                    GameManager.ConfirmaTurno = true;
                                    GameManager.Points_Clima_A = mazo1.Hand[carta_mano].GetComponent<Card>();
                                    mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                    mazo1.Hand.RemoveAt(carta_mano);
                                }
                            }
                        }

                        if (campocarta("Despeje", mazo1.Hand, carta_mano))
                        {
                            if (campo == 10)
                            {
                                for (int i = 0; i < mazo1.PosClima.Count; i++)
                                {
                                        mazo1.PosClima[i].texture = null;
                                        GameManager.ConfirmaTurno = true;
                                        GameManager.Points_Clima_A = null;
                                        GameManager.Points_Clima_D = null;
                                        GameManager.Points_Clima_C = null;  
                                }
                                mazo1.PosDespeje.texture = imagecard.texture;
                                imagecard.texture = null;
                                mazo1.Cementerio.Add(mazo1.Hand[carta_mano]);
                                mazo1.Hand.RemoveAt(carta_mano);
                            }
                        }

                        if (campocarta("Senuelo", mazo1.Hand, carta_mano))
                        {
                            if (campo == 11)
                            {
                                int A = GameManager.mayor_carta(GameManager.Points_Slytherin_C);
                                string name = GameManager.Points_Slytherin_C[A].name;

                                for (int i = 0; i < mazo1.PosCuerpoacuerpo.Count; i++)
                                {
                                    if (GameManager.Points_Slytherin_C[A].GetComponent<SpriteRenderer>().sprite.texture == mazo1.PosCuerpoacuerpo[i].texture)
                                    {
                                        mazo1.PosCuerpoacuerpo[i].texture = imagecard.texture;
                                        break;
                                    }
                                }
                                for (int j = 0; j < mazo1.Cementerio.Count; j++)
                                {
                                    if (mazo1.Cementerio[j].GetComponent<Card>().name == name)
                                    {
                                        mazo1.Hand.RemoveAt(carta_mano);
                                        mazo1.Hand.Add(mazo1.Cementerio[j]);
                                        break;
                                    }
                                }
                                GameManager.Points_Slytherin_C.RemoveAt(A);
                                GameManager.ConfirmaTurno = true;
                            }
                            if (campo == 12)
                            {
                                int A = GameManager.mayor_carta(GameManager.Points_Slytherin_D);
                                string name = GameManager.Points_Slytherin_D[A].name;

                                for (int i = 0; i < mazo1.PosDistancia.Count; i++)
                                {
                                    if (GameManager.Points_Slytherin_D[A].GetComponent<SpriteRenderer>().sprite.texture == mazo1.PosDistancia[i].texture)
                                    {
                                        mazo1.PosDistancia[i].texture = imagecard.texture;
                                        break;
                                    }
                                }
                                for (int j = 0; j < mazo1.Cementerio.Count; j++)
                                {
                                    if (mazo1.Cementerio[j].GetComponent<Card>().name == name)
                                    {
                                        mazo1.Hand.RemoveAt(carta_mano);
                                        mazo1.Hand.Add(mazo1.Cementerio[j]);
                                        break;
                                    }
                                }
                                GameManager.Points_Slytherin_D.RemoveAt(A);
                                GameManager.ConfirmaTurno = true;
                            }
                            if (campo == 13)
                            {
                                int A = GameManager.mayor_carta(GameManager.Points_Slytherin_A);
                                string name = GameManager.Points_Slytherin_A[A].name;

                                for (int i = 0; i < mazo1.PosAsedio.Count; i++)
                                {
                                    if (GameManager.Points_Slytherin_A[A].GetComponent<SpriteRenderer>().sprite.texture == mazo1.PosAsedio[i].texture)
                                    {
                                        mazo1.PosAsedio[i].texture = imagecard.texture;
                                        break;
                                    }
                                }
                                for (int j = 0; j < mazo1.Cementerio.Count; j++)
                                {
                                    if (mazo1.Cementerio[j].GetComponent<Card>().name == name)
                                    {
                                        mazo1.Hand.RemoveAt(carta_mano);
                                        mazo1.Hand.Add(mazo1.Cementerio[j]);
                                        break;
                                    }
                                }
                                GameManager.Points_Slytherin_A.RemoveAt(A);
                                GameManager.ConfirmaTurno = true;
                            }
                        }
                    }
                }
            }
           
        }
        
    }
    public bool campocarta(string verificacion, List<GameObject> hand,int carta_a_revisar) //funcion que comprueba si el campo que le corresponde a la carta
    {
        for(int i = 0; i < hand[carta_a_revisar].GetComponent<Card>().campo.Length;i++) //recorre las propiedades de campo asociadas a la carta 
        {
            if (hand[carta_a_revisar].GetComponent<Card>().campo[i].ToString() == verificacion) //si se encuentra la propiedad retorna true
            {
                return true;
            }
        }
        return false;
    }

    public void searching_effect(Card carta, string efecto, hogwartsdeck mazo_propio, hogwartsdeck mazo_adversario, List<RawImage> fila, List<RawImage> fila2) //funcion que comprueba si la carta posee algun efecto
    {
        if ((carta.hability != Superpower.own) && (carta.hability != Superpower.none)) // si la carta tiene habilidad llama a la funcion de efecto para que lo ejecute
        {
          effect(carta, efecto, mazo_propio,mazo_adversario, fila, fila2); //pasa la carta de la mano, la propiedad de efecto, el mazo que le corresponde y la fila en que se ejecuta, y estos ultimos del adversario
        }
    }

    public void effect(Card card, string efecto , hogwartsdeck mazo_propio, hogwartsdeck mazo_adversario, List<RawImage> fila, List<RawImage> fila2) //funcion que ejecuta el efecto de la carta
    {
     switch (efecto)
     {
            case "rob_":
                mazo_propio.rob(1);
                break;

           case "add_aumento": //agrega la misma carta en la posicion de aumento en que se invoco
                if (fila == mazo_propio.PosAsedio)
                {
                    if (mazo_propio == mazo)
                    {
                        if (GameManager.Points_Gryffindor_Aumento_A == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Gryffindor_Aumento_A = card;
                        }
                    }
                    else
                    {
                        if (GameManager.Points_Slytherin_Aumento_A == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Slytherin_Aumento_A = card;
                        }
                    }
                }
                if (fila == mazo_propio.PosCuerpoacuerpo)
                {
                    if (mazo_propio == mazo)
                    {
                        if (GameManager.Points_Gryffindor_Aumento_C == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Gryffindor_Aumento_C = card;
                        }
                    }
                    else
                    {
                        if (GameManager.Points_Slytherin_Aumento_C == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Slytherin_Aumento_C = card;
                        }
                    }
                }
                if (fila == mazo_propio.PosDistancia)
                {
                    if (mazo_propio == mazo)
                    {
                        if (GameManager.Points_Gryffindor_Aumento_D == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Gryffindor_Aumento_D = card;
                        }
                    }
                    else
                    {
                        if (GameManager.Points_Slytherin_Aumento_D == null)
                        {
                            mazo_propio.PosAumento[2].texture = imagecard.texture;
                            GameManager.Points_Slytherin_Aumento_D = card;
                        }
                    }
                }

                break;

            case "add_clima": //agrega la misma carta en la posicion de clima en que se invoco
                if (fila == mazo_propio.PosAsedio)
                {
                    mazo_propio.PosClima[2].texture = imagecard.texture;
                    GameManager.Points_Clima_A = card;
                }
                if (fila == mazo_propio.PosDistancia)
                {
                    mazo_propio.PosClima[1].texture = imagecard.texture;
                    GameManager.Points_Clima_D = card;
                }
                if (fila == mazo_propio.PosCuerpoacuerpo)
                {
                    mazo_propio.PosClima[0].texture = imagecard.texture;
                    GameManager.Points_Clima_C = card;
                }
                break;

            case "clean_j_down": //limpia la fila del adversario con mayor cantidad de cartas en su totalidad
                List<RawImage> mayores = ListWithMayorElement(mazo_adversario.PosCuerpoacuerpo, mazo_adversario.PosDistancia, mazo_adversario.PosAsedio);
                for (int i = 0; i < mayores.Count; i++)
                {
                    mayores[i].texture = null;
                    GameManager.Puntos_asociados(mayores).Clear();
                }
                break;

            case "clean_card_up": //busca la cata con mayor poder del adversario en la fila en que fue invoado

                    /*int A = GameManager.mayor_carta(GameManager.Puntos_asociados(fila2));

                    for (int i = 0; i < fila2.Count; i++)
                    {
                        if (GameManager.Puntos_asociados(fila2)[A].GetComponent<SpriteRenderer>().sprite.texture == fila2[i].texture) //comprueba si la imagen de la carta la posee algun raw image en la lista de posiciones de esa fila
                        {
                            fila2[i].texture = null;
                            break; //solo toma el primero en caso de la carta este repetida
                        }
                    GameManager.Puntos_asociados(fila2).RemoveAt(A);
                    }*/
                    break;
     }
    }

    public List<RawImage> ListWithMayorElement(List<RawImage> lista1, List<RawImage> lista2, List<RawImage> lista3)
    {
        int count1 = CountNonNullTextures(lista1);
        int count2 = CountNonNullTextures(lista2);
        int count3 = CountNonNullTextures(lista3);

        int maxCount = Math.Max(count1, Math.Max(count2, count3)); //encuentra la mayor fila segun el contador de cada una y retorna por casos la que mas tenga

        if (maxCount == count1)
        {
            return lista1;
        }
        else if (maxCount == count2)
        {
            return lista2;
        }
        else if (maxCount == count3)
        {
            return lista3;
        }
        return null; //si no existe no retorna nada
    }

    private int CountNonNullTextures(List<RawImage> list) //retorna la cantidad de raw images no nulos de una lista
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.texture != null)
            {
                count++;
            }
        }
        return count;
    }
}
