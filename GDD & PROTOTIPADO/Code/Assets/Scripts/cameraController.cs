using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float mouseSensitivy;

    public GameObject Player;
    public GameObject childFront;
    public GameObject look;

    private float speed = 10;

    //private float minDistancia = 1f;
    //private float maxDistancia = 5f;
    //private float distancia;
    
    //Vector3 direccion;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        childFront = Player.transform.Find("constraint").gameObject;
        look = Player.transform.Find("look").gameObject;
        //direccion = transform.localPosition.normalized;
        //distancia = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followAndRotate();
        //camCollision();
    }

    private void followAndRotate() {
        var xPos = Input.GetAxis("Mouse X");
        var yPos = Input.GetAxis("Mouse Y");

        gameObject.transform.position = Vector3.Lerp(transform.position, childFront.transform.position, Time.deltaTime * speed);

        if (SimpleInput.GetAxis("FreeLook") > 0) {
            float cam = transform.eulerAngles.x;
            var rotationLR = transform.localEulerAngles;
            rotationLR.y += xPos * mouseSensitivy;
            
            transform.rotation = Quaternion.AngleAxis(rotationLR.y, Vector3.up);
            transform.Rotate(cam, 0f, 0f, Space.Self);
        } else {
            gameObject.transform.LookAt(look.gameObject.transform.position);
        }
    }

    //private void camCollision() {
    //    Vector3 posDeCamara = transform.TransformPoint(direccion * maxDistancia);
    //    RaycastHit hit;
    //    if(Physics.Linecast(transform.position, posDeCamara, out hit)) {
    //        distancia = Mathf.Clamp(hit.distance * 0.85f, minDistancia, maxDistancia);
    //    } else {
    //        distancia = maxDistancia;
    //    }
    //    transform.position = Vector3.Lerp(transform.position, direccion * distancia, Time.deltaTime);
    //}
}

