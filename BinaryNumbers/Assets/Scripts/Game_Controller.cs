using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Game_Controller : MonoBehaviour {

    [Header("UI")]
    public RawImage background;
    public GameObject uiIdle;
    public GameObject UI_Game;

    public string palabra = "otra";
    private char[] binarioString = new char[] { '0', '0', '0', '0', '0' };
    private int countPalabra;

    public GameObject[] Body;
    private int actualBody = 0;

    public Text[] letras;// Text - Muestra cada letra de la palabra
    public Text[] binarios;// Text - Muestra el texto de los botones 1 - 2 - 4 - 8 - 16

    [Header("UI_Score")]
    public GameObject UI_Score;
    public Text Win_or_Fail;
    public Text Puntaje; 

    private Diccionario dic = new Diccionario();
    private List<int> posiciones = new List<int>();
    private int totalAsiertos = 0;

    void Start() {
        countPalabra = palabra.Length;//Asignacion - Obtiene el tamaño de la palabra
        Inicializar_Letras();

    }
    void Update() {
        //Empieza el juego
        if (Input.GetKeyDown("a"))
        {
            uiIdle.SetActive(false);
            UI_Game.SetActive(true);
        }
    }
    ///////////////////////////////////////////////////////////////////////////
    /////////////////////////// ----- METODOS ----- ///////////////////////////
    ///////////////////////////////////////////////////////////////////////////


    private void Inicializar_Letras()
    {
        for(int i=0;i< countPalabra; i++)
        {
            letras[i].text = palabra[i].ToString();
            letras[i].color = new Color(0, 255, 255, 1);
        }
    }
    public void ActualizarBinarios(int B)
    {
        if (binarioString[B] == '0')
        {
            binarioString[B] = '1';
            binarios[B].text = "1";
        }
        else
        {
            binarioString[B] = '0';
            binarios[B].text = "0";
        }
    }
    public void Validar_Binario()
    {
        string aux = binarioString[0].ToString() + binarioString[1].ToString() + binarioString[2].ToString() + binarioString[3].ToString() + binarioString[4].ToString();
        for (int i = 0; i < countPalabra; i++)//hace la comparacion con cada letra en su forma binaria
        {
            if(aux == dic.obtenerKey(palabra[i]))//Compara el binario ingresado con el binario de la letra
            {
                posiciones.Add(i);//si es verdadero, guarda la posicion de la letra correcta
            }
        }

        if(posiciones.Count!=0)//verifica si por lo menos hay una letra correcta
        {
            for (int i=0;i<posiciones.Count;i++)
            {
                if(letras[posiciones[i]].color == new Color(0, 0, 255, 1))
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
                    if (totalAsiertos >= countPalabra)
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
        Puntaje.GetComponent<Text>().text = (((totalAsiertos*20)/(countPalabra))).ToString();
        UI_Game.SetActive(false);
        UI_Score.SetActive(true);
    }
}
