using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Objetos", menuName = "GameItems")]
public class Objects : ScriptableObject
{
    public string nombre;
    public string fullName;
    public bool recogido=false;
    [HideInInspector]
    public GameObject spawn;

    public void findHotspot()
    {
        recogido = false;
        spawn = GameObject.Find(nombre);
        spawn.SetActive(false);
    }

    
}


