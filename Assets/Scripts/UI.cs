using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Image p1Health;
    public Image p2Health;
    Health health1;
    Health health2;
    GameObject player1;
    GameObject player2;
    GameObject manager;
    public int hp1;
    public int hp2;
    Manager main;
    double lives1;
    double lives2;

    private float maxHealth = 100;

    private void Start()
    {
        //recebe os objectos respetivos a cada um dos jogadores
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        //Recebe o script Health de cada um dos players
        health1 = player1.GetComponent<Health>();
        health2 = player2.GetComponent<Health>();

        //recebe o objeto que contem o script manager
        manager = GameObject.Find("Manager");

        //recebe o script manager
        main = manager.GetComponent<Manager>();


    }

    private void Update()
    {
        UpdateHealthBar1();
        UpdateHealthBar2();
    }

    //Muda dinamicamente a barra de HP da vida do player
    public void UpdateHealthBar1()
    {
        hp1 = health1.currentHealth;
        //ratio dá nos um valor de 0 a 1 da vida
        float ratio = hp1 / maxHealth;
        //muda o tamanha da barra
        p1Health.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
    public void UpdateHealthBar2()
    {
        hp2 = health2.currentHealth;
        //ratio dá nos um valor de 0 a 1 da vida
        float ratio = hp2 / maxHealth;
        //muda o tamanha da bara
        p2Health.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void HideHearths1()
    {
        //divide-se por 4 porque no update do Detect o contador quando é ativo incrementa 5
        lives1 = main.lives1;
        if(lives1 == 3) GameObject.Find("hearth3P1").SetActive(false);
        if (lives1 == 2) GameObject.Find("hearth2P1").SetActive(false);
        if (lives1 == 1) GameObject.Find("hearth1P1").SetActive(false);
    }
    public void HideHearths2()
    {
        lives2 = main.lives2;
        if (lives2 == 3) GameObject.Find("hearth3P2").SetActive(false);
        if (lives2 == 2) GameObject.Find("hearth2P2").SetActive(false);
        if (lives2 == 1) GameObject.Find("hearth1P2").SetActive(false);
    }



}
