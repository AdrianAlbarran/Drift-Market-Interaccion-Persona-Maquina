using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu, startGameMenu;
    public GameObject optionsFirstButton, optionsCloseButton;

    public void playGame()
    {
        startGameMenu.SetActive(false);
        startGameMenu.SetActive(false);
        Time.timeScale = 0f;
        // Se cambia a la escena del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openOptions()
    {
        optionsMenu.SetActive(true);
        startGameMenu.SetActive(false);
        startGameMenu.SetActive(false);


        // Empty the selected object (needed before selecting another one)
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void closeOptions()
    {
        optionsMenu.SetActive(false);
        startGameMenu.SetActive(true);

        // Empty the selected object (needed before selecting another one)
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void quitGame()
    {
        Debug.Log("QUIT GAME!");
        Application.Quit();
    }
}
