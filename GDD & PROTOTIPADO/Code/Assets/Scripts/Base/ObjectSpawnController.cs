using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    public GameObject[] spawns;

    public List<Objects> objetosActivos;

    public void Start()
    {
        objetosActivos = GameObject.Find("Game Manager").GetComponent<ShoppingList>().listObjects;
        Spawn();

    }

    private void Spawn()
    {
        foreach (Objects i in objetosActivos)
        {
            for(int j = 0;j < spawns.Length; j++)
            {
                if(i.nombre == spawns[j].name)
                {
                    spawns[j].SetActive(true);
                }
            }
        }
    }
}
