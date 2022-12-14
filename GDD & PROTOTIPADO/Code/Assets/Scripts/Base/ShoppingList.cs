using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShoppingList : MonoBehaviour
{
    [SerializeField]
    private Objects[] allObjects;

    public List<Objects> listObjects;

    [SerializeField]
    private int listSize;

    private List<int> usedValues;

    [SerializeField]
    private GameObject uiList;

    private bool fullList;

    [HideInInspector]
    public Timer timer;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.createTimer(180,timerText);
        openList();
        updateList(toString());
    }

    public void objectTaken()
    {
        updateList(toString());
    }

    public void openList()
    {
        for (int i = 0; i < allObjects.Length; i++)
        {
            allObjects[i].findHotspot();
        }
        usedValues = new List<int>();
        for (int i = 0; i < listSize; i++)
        {
            int val = Random.Range(0, allObjects.Length);
            if (usedValues.Count == 0)
            {
                usedValues.Add(val);
                allObjects[val].spawn.SetActive(true);
                listObjects.Add(allObjects[val]);
            }
            else
            {
                while (usedValues.Contains(val))
                {
                    val = Random.Range(0, allObjects.Length);
                }
                usedValues.Add(val);
                allObjects[val].spawn.SetActive(true);
                listObjects.Add(allObjects[val]);
            }
        }
    }

    public void updateList(string list)
    {
        TextMeshProUGUI viewedList = uiList.GetComponent<TextMeshProUGUI>();

        viewedList.text = list;

        fullList = completedList();

        if (fullList)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene("Win_Scene");
            }
            EventSystem.current.SetSelectedGameObject(null);
        }

    }

    public string toString()
    {
        string listString = "";
        for (int i = 0; i < listSize; i++)
        {
            if (listObjects[i].recogido)
            {
                listString = listString + "<s>" + listObjects[i].fullName.ToString() + "</s>" + "\n";
            }
            else
            {
                listString = listString + listObjects[i].fullName.ToString() + "\n";
            }
        }
        return listString;
    }

    public bool completedList()
    {
        bool aux = true;
        for (int i = 0; i < listObjects.Count; i++)
        {
            if (listObjects[i].recogido == false)
            {
                aux = false;
            }
        }
        timer.setTimer(!aux);
        return aux;
    }
}