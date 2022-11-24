using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;

public class MenuInGame : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu, selectModeMenu;
    public GameObject pauseFirstButton, optionsFirstButton, optionsCloseButton, selectModeFirstButton;

    public void returnGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        // A�adir que pueda usar el boton de opciones del mando y el volante, ni idea de como
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy)
        {
            onPause();
        }
    }

    private void Awake()
    {
        Time.timeScale = 0f;
        selectModeMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectModeFirstButton);
    }

    public void onPause()
    {
        if (!pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !selectModeMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            
            // Empty the selected object (needed before selecting another one)
            EventSystem.current.SetSelectedGameObject(null);
            //Set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);

        }
    }

    public void openOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);

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

    public void volverMainMenu()
    {
        selectModeMenu.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void normalMode()
    {
        ShoppingList list = GameObject.Find("Game Manager").GetComponent<ShoppingList>();
        list.timer.setMode(true);
        list.timer.setTime(0);
        selectModeMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void clockMode()
    {
        ShoppingList list = GameObject.Find("Game Manager").GetComponent<ShoppingList>();
        list.timer.setMode(false);
        selectModeMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}