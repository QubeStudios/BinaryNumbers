using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Game_Master : MonoBehaviour {
    [Header("UI_Star")]
    public GameObject Comenzar;
    public GameObject UI_Game;
    public GameObject UI_Canvas_Game;

    public string palabra = "";//Palabra con la que iniciara el juego
    private int tamañoPalabra;//Obtendra el tamaño de la palabra

    public GameObject[] Body;//Partes del ahorcado
    private int actualBody = 0;

    [Header("UI_Score")]
    public GameObject UI_Score;
    public Text Win_or_Fail;
    public Text Puntaje;

    private Diccionario dic = new Diccionario();
    private List<int> posiciones = new List<int>();
    private int totalAsiertos = 0;

    public Text[] letras;// Text - Muestra cada letra de la palabra

    ///////////////////    OTRAS VARIABLES
    public string[] binarioString = new string[] { "0", "0", "0", "0", "0" };

    // Use this for initialization
    void Start () {
        tamañoPalabra = palabra.Length;//Asignacion - Obtiene el tamaño de la palabra
        Inicializar_Letras();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
        {
            Comenzar.SetActive(false);
            UI_Game.SetActive(true);
            UI_Canvas_Game.SetActive(true);
        }
	}

    ///////////////////////////////////////////////////////////////////////////
    /////////////////////////// ----- METODOS ----- ///////////////////////////
    ///////////////////////////////////////////////////////////////////////////


    private void Inicializar_Letras()
    {
        for (int i = 0; i < tamañoPalabra; i++)
        {
            letras[i].text = palabra[i].ToString();
            letras[i].color = new Color(0, 255, 255, 1);
        }
    }
    public void Validar_Binario()
    {
        string aux = binarioString[4] + binarioString[3] + binarioString[2]+ binarioString[1]+ binarioString[0];
        Debug.Log(aux);
        for (int i = 0; i < tamañoPalabra; i++)//hace la comparacion con cada letra en su forma binaria
        {
            if (aux == dic.obtenerKey(palabra[i]))//Compara el binario ingresado con el binario de la letra
            {
                posiciones.Add(i);//si es verdadero, guarda la posicion de la letra correcta
            }
        }

        if (posiciones.Count != 0)//verifica si por lo menos hay una letra correcta
        {
            for (int i = 0; i < posiciones.Count; i++)
            {
                if (letras[posiciones[i]].color == new Color(0, 0, 255, 1))
                {
                    if (actualBody < 5)
                    {
                        Body[actualBody].SetActive(true);
                        actualBody++;
                        posiciones.Clear();
                        break;
                    }
                    else
                        Mostrar_UI_Score("PERDISTE MANCO DE MIERDA :C");
                }
                else
                {
                    letras[posiciones[i]].color = new Color(0, 0, 255, 1);
                    totalAsiertos++;
                    if (totalAsiertos >= tamañoPalabra)
                        Mostrar_UI_Score("¡¡GANASTE!!");
                }
            }
        }
        else
        {
            if (actualBody < 5)
            {
                Body[actualBody].SetActive(true);
                actualBody++;
            }
            else
            {
                Mostrar_UI_Score("PERDISTE MANCO DE MIERDA :C");
            }
        }
        posiciones.Clear();
    }
    void Mostrar_UI_Score(string textWinLose)
    {
        Win_or_Fail.GetComponent<Text>().text = textWinLose;
        Puntaje.GetComponent<Text>().text = (((totalAsiertos * 20) / (tamañoPalabra))).ToString();
        UI_Game.SetActive(false);
        UI_Canvas_Game.SetActive(false);
        UI_Score.SetActive(true);
    }
}
