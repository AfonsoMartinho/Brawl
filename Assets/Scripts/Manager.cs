using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public GameObject p1Winner;
    public GameObject p2Winner;
    Health health1;
    Health health2;
    GameObject player1;
    GameObject player2;
    public int currentHealth1;
    public int currentHealth2;
    GameObject raycast;
    Detect_fall fall;
    public bool p1falls;
    public bool p2falls;
    public int lives1;
    public int lives2;
    bool oneTime;
    GameObject theCanvas;
    UI ui;
    Vector3 spawn1;
    Vector3 spawn2;

    //Variaveis para SaveGame
    private int score1;
    private int score2;

    public int cor1;
    public int cor2;


    // Use this for initialization
    void Start()
    {
        cor1 = PlayerPrefs.GetInt("cor1", 0);
        cor2 = PlayerPrefs.GetInt("cor2", 0);
    //recebe os objectos respetivos a cada um dos jogadores
    player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        //Recebe o script Health de cada um dos players
        health1 = player1.GetComponent<Health>();
        health2 = player2.GetComponent<Health>();

        //recebe o objecto com o ray
        raycast = GameObject.Find("Raycast");

        //recebe o script Detect_fall do raycast
        fall = raycast.GetComponent<Detect_fall>();

        //recebe o objeto Canvas
        theCanvas = GameObject.Find("Canvas");

        //recebe o script UI do canvas;
        ui = theCanvas.GetComponent<UI>();

        lives1 = 4;
        lives2 = 4;

        oneTime = true;

        spawn1 = new Vector3(0, 1, 0);
        spawn2 = new Vector3(0, 0, -2);

        if (cor1 == 0) player1.GetComponent<Renderer>().material.color = Color.green;
        if (cor1 == 1) player1.GetComponent<Renderer>().material.color = Color.blue;
        if (cor1 == 2) player1.GetComponent<Renderer>().material.color = Color.white;

        if (cor2 == 0) player2.GetComponent<Renderer>().material.color = Color.yellow;
        if (cor2 == 1) player2.GetComponent<Renderer>().material.color = Color.red;
        if (cor2 == 2) player2.GetComponent<Renderer>().material.color = Color.black;

    }

    // Update is called once per frame
    void Update()
    {
        //recebe a vida atual de cada umn dos Players
        currentHealth1 = health1.currentHealth;
        currentHealth2 = health2.currentHealth;

        //recebe as variaveis booleanas referentes à queda de cada um do Players
        p1falls = fall.p1Falls;
        p2falls = fall.p2Falls;

        if (p1falls || currentHealth1 <= 0)
        {
            //oneTime é usado para chamar a fução só uma vez
            if (oneTime)
            {
                //Tira uma vida
                lives1--;
                ui.HideHearths1();
                oneTime = false;
                //Faz o respawn
                Respawn1();
            }
        }

        if (p2falls || currentHealth2 <= 0)
        {
            // oneTime é usado para chamar a fução só uma vez
            if (oneTime)
            {
                //Tira uma vida
                lives2--;
                ui.HideHearths2();
                oneTime = false;
                //Faz o REspwan
                Respawn2();

            }
        }
        if (lives1 == 0)
        {
            EndGame(1);
        }
        if (lives2 == 0)
        {
            EndGame(2);
        }

    }
    public void Respawn1()
    {
        
        player1.transform.position = spawn1;
        fall.p1Falls = false;

        //coloca  a vida do player no maximo
        health1.enabled = false;
        health1.enabled = true;

        oneTime = true;
        
    }
    public void Respawn2()
    {
       
        player2.transform.position = spawn2;
        fall.p2Falls = false;

        //coloca  a vida do player no maximo
        health2.enabled = false;
        health2.enabled = true;

        oneTime = true;
        
    }
    public void EndGame(int player)
    {
        //TODO add to scoreboard
        if (player == 1)
        {
            Debug.Log("P1 Loose");
            p2Winner.SetActive(true);


        }
        if (player == 2)
        {
            Debug.Log("P2 Loose");
            p1Winner.SetActive(true);
            

        }
    }
}
