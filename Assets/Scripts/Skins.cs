using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    Color[] colors1 = { Color.green, Color.blue, Color.white };
    Color[] colors2 = { Color.yellow, Color.red, Color.black };
    private int counter1;
    private int counter2;

    bool aKey1;
    bool next1;
    bool prev1;

    bool aKey2;
    bool next2;
    bool prev2;

    // Use this for initialization
    void Start()
    {
        counter1 = 0;
        counter2 = 0;
        player1.GetComponent<Renderer>().material.color = colors1[1];
        player2.GetComponent<Renderer>().material.color = colors2[1];

        aKey1 = false;
        next1 = false;
        prev1 = false;

        aKey2 = false;
        next2 = false;
        prev2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        seeKeysPressed();
        if (next1) SetColor("next", 1);
        if (prev1) SetColor("prev", 1);

        if (next2) SetColor("next", 2);
        if (prev2) SetColor("prev", 2);
    }
    public void SetColor(string direction, int player)
    {


        if (direction == "next")
        {
            if (player == 1)
                if (counter1 < 2)
                    counter1++;
            if (player == 2)
                if (counter2 < 2)
                    counter2++;
        }
        if (direction == "prev")
        {
            if (player == 1)
                if (counter1 > 0)
                    counter1--;
            if (player == 2)
                if (counter2 > 0)
                    counter2--;
        }
        player1.GetComponent<Renderer>().material.color = colors1[counter1];
        player2.GetComponent<Renderer>().material.color = colors2[counter2];

    }
    //Storing Keys on bool values
    void seeKeysPressed()
    {
        aKey1 = Input.GetButtonDown("AButton");
        next1 = Input.GetButtonDown("RbButton");
        prev1 = Input.GetButtonDown("LbButton");

        aKey2 = Input.GetButtonDown("AButton2");
        next2 = Input.GetButtonDown("RbButton2");
        prev2 = Input.GetButtonDown("LbButton2");

    }
    public void SaveColor()
    {
        PlayerPrefs.SetInt("cor1", counter1);
        PlayerPrefs.SetInt("cor2", counter2);
    }
}
