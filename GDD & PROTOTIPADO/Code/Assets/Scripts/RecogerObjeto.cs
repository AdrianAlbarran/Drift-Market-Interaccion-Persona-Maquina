using TMPro;
using UnityEngine;

public class RecogerObjeto : MonoBehaviour
{
    public GameObject UI;

    public Objects nObjeto;

    public ShoppingList lista;

    private bool recogido;

    [SerializeField]
    private GameObject prefab;


    private void Start()
    {
        Instantiate(prefab, transform.position+new Vector3(0,-2,0), prefab.transform.rotation,transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            UI.gameObject.SetActive(true);
            UI.GetComponent<TextMeshProUGUI>().text = "<color=#FF5BD2FF> Pulsa X/F</color> <color=#FFFFFF>para Recoger</color> <color=#59FFB3FF>" + nObjeto.fullName +"</color>";
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
            if (SimpleInput.GetAxis("PickUp") > 0)
            {
                recogido = false;
                AudioManager.instance.Play("CogerObjeto");
                nObjeto.recogido = true;
                lista.objectTaken();
                GetComponent<Light>().enabled=false;
                UI.gameObject.SetActive(false);
                Destroy(GameObject.Find(prefab.name+"(Clone)"));
                
                Destroy(this);
            }
        }
    }
}