using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public GameObject Player;
    public GameObject childFront;
    public GameObject childBack;
    public GameObject look;
    public GameObject lookBehind;
    public float speed;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        childFront = Player.transform.Find("constraint").gameObject;
        childBack = Player.transform.Find("constraintBack").gameObject;
        look = Player.transform.Find("look").gameObject;
        lookBehind = Player.transform.Find("lookBehind").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        follow();
    }

    private void follow() {
        if (Input.GetAxis("Vertical") < -0.5) {
            gameObject.transform.position = Vector3.Lerp(transform.position, childBack.transform.position, Time.deltaTime * speed);
            gameObject.transform.LookAt(lookBehind.gameObject.transform.position);
        } else {
            gameObject.transform.position = Vector3.Lerp(transform.position, childFront.transform.position, Time.deltaTime * speed);
            gameObject.transform.LookAt(look.gameObject.transform.position);
        }
    }
}
