using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private void Start()
    {
        openList();
        updateList(toString());
        objectTaken(listObjects[1]);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void objectTaken(Objects aux)
    {
        int idx = listObjects.BinarySearch(aux);
        listObjects[idx].recogido = true;
        updateList(toString());
    }

    public void openList()
    {
        usedValues = new List<int>();
        for (int i = 0; i < listSize; i++)
        {
            int val = Random.Range(0, allObjects.Length - 1);
            if (usedValues.Count == 0)
            {
                usedValues.Add(val);
                listObjects.Add(allObjects[val]);
            }
            else
            {
                while (usedValues.Contains(val))
                {
                    val = Random.Range(0, allObjects.Length - 1);
                }
                usedValues.Add(val);
                listObjects.Add(allObjects[val]);
            }
        }
    }

    public void updateList(string list)
    {
        TextMeshProUGUI viewedList = uiList.GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < listSize; i++)
        {
            viewedList.text = list;
        }
    }

    public string toString()
    {
        string listString = "";
        for (int i = 0; i < listSize; i++)
        {
            if (listObjects[i].recogido)
            {
                listString = listString + "<s>" + listObjects[i].nombre.ToString() + "</s>" + "\n";
            }
            else
            {
                listString = listString + listObjects[i].nombre.ToString() + "\n";
            }
        }
        return listString;
    }
}