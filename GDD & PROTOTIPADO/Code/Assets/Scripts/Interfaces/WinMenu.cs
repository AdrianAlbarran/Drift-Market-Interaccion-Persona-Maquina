using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class WinMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Menu_Inicial");
    }

    public void quitGame()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
