using TMPro;
using UnityEngine;

public class RecogerObjeto : MonoBehaviour
{
    public GameObject UI;

    public Objects nObjeto;

    public ShoppingList lista;

    private bool recogido;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            UI.gameObject.SetActive(true);
            UI.GetComponent<TextMeshProUGUI>().text = "Pulsa F para Recoger " + nObjeto.fullName;
            recogido = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            UI.gameObject.SetActive(false);
            recogido = false;
        }
    }

    public void Update()
    {
        if (UI.activeSelf && recogido)
        {
            if (Input.GetKeyDown("f"))
            {
                recogido = false;
                nObjeto.recogido = true;
                lista.objectTaken();
                GetComponent<Light>().enabled=false;
                UI.gameObject.SetActive(false);
                
                Destroy(this);
            }
        }
    }
}