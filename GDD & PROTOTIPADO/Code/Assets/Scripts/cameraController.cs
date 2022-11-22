using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float mouseSensitivy;
    public Camera _mainCamera;

    public GameObject Player;
    public GameObject childFront;
    public GameObject childBack;
    public GameObject look;
    public GameObject lookBehind;
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

        if (Input.GetKey(KeyCode.X)) {
            var rotationLR = transform.localEulerAngles;
            rotationLR.y += xPos * mouseSensitivy;
            transform.rotation = Quaternion.AngleAxis(rotationLR.y, Vector3.up);
        } else {
            gameObject.transform.LookAt(look.gameObject.transform.position);
        }
    }
}
