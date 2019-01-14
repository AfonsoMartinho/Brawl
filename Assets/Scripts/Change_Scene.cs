using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour {

    public void CharSelection()
    {
        SceneManager.LoadScene("Scenes/CharSelector");
    }
    public void QuitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }
    public void Level1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
