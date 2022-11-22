using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu;
    public GameObject pauseFirstButton, optionsFirstButton, optionsCloseButton;

    public void playGame()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    void Update()
    {
        // Añadir que pueda usar el boton de opciones del mando y el volante, ni idea de como
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            onPause();
        }
    }

    public void onPause()
    {
        if(!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            // Empty the selected object (needed before selecting another one)
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            optionsMenu.SetActive(true);
        }
    }

    public void openOptions()
    {
        optionsMenu.SetActive(true);

        // Empty the selected object (needed before selecting another one)
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void closeOptions()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);

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
