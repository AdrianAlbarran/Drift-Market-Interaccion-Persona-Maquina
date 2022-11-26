using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("A GameManager already in scene");
            Destroy(gameObject);
        }

        instance = this;

    }

}
