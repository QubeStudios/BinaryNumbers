using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Carta : MonoBehaviour {

    public Animator animator;
    public Text binario;
    public int posicion;
    public Game_Master game_Master;
    private Diccionario dic = new Diccionario();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        if(animator.GetBool("Cara")==true)
        {
            animator.SetBool("Cara", false);
            binario.text = "0";
            game_Master.binarioString[posicion] = "0";
        }
        else
        {
            animator.SetBool("Cara", true);
            binario.text = "1";
            game_Master.binarioString[posicion] = "1";
        }
    }
   
}
