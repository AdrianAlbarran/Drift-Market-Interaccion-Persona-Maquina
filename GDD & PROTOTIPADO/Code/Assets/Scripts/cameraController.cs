using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float mouseSensitivy;

    public GameObject Player;
    public GameObject childFront;
    public GameObject look;

    public float speed;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        childFront = Player.transform.Find("constraint").gameObject;
        look = Player.transform.Find("look").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followAndRotate();
    }

    private void followAndRotate() {
        var xPos = Input.GetAxis("Mouse X");
        var yPos = Input.GetAxis("Mouse Y");

        gameObject.transform.position = Vector3.Lerp(transform.position, childFront.transform.position, Time.deltaTime * speed);

        if (Input.GetAxis("FreeLook") == 1) {
            float cam = transform.eulerAngles.x;
            var rotationLR = transform.localEulerAngles;
            rotationLR.y += xPos * mouseSensitivy;
            
            transform.rotation = Quaternion.AngleAxis(rotationLR.y, Vector3.up);
            transform.Rotate(cam, 0f, 0f, Space.Self);
        } else {
            gameObject.transform.LookAt(look.gameObject.transform.position);
        }
    }
}
