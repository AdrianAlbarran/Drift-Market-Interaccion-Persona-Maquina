using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerObjeto : MonoBehaviour
{
    public GameObject UI;
    private GameObject luz;
    private bool objetoRecogido;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            UI.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            UI.gameObject.SetActive(false);
        }
    }
    public void Update()
    {

        if (UI.activeSelf && !objetoRecogido)
        {
            if (Input.GetKeyDown("f"))
            {
                luz = GameObject.Find("Spot Light");
                luz.SetActive(false);
                UI.gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }
}
