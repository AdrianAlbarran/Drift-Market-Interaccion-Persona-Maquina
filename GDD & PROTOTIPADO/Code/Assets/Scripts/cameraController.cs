using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float mouseSensitivy;

    public GameObject Player;
    public GameObject childFront;
    public GameObject look;

    public Rigidbody rb;

    private float speed = 15;
    private float speedRot = 35;

    private Vector3 childFrontPos;

    private void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        childFront = Player.transform.Find("constraint").gameObject;
        look = Player.transform.Find("look").gameObject;
        childFrontPos = childFront.transform.localPosition;
        rb = Player.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        followAndRotate();
    }

    private void followAndRotate() {
        transform.position = Vector3.Lerp(transform.position, childFront.transform.position, Time.deltaTime * speed);
        float mouseX = SimpleInput.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = SimpleInput.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;
        transform.RotateAround(Player.transform.position, Vector3.up, mouseX);
        transform.RotateAround(Player.transform.position, transform.right, -mouseY);

        Quaternion targetRotation = Quaternion.LookRotation(look.transform.position - transform.position);
        if (SimpleInput.GetAxis("Horizontal") > 0.5 || SimpleInput.GetAxis("Vertical") > 0.5 || SimpleInput.GetAxis("Horizontal") < -0.5 || SimpleInput.GetAxis("Vertical") < -0.5 || rb.velocity.magnitude > 3f) {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRot * Time.deltaTime);
        }

        //camCollision
        RaycastHit hit;
        if (Physics.Raycast(childFront.transform.position, transform.position - childFront.transform.position, out hit, 6f)) {
            if (hit.transform.tag != "Player") {
                childFront.transform.localPosition = Vector3.Lerp(childFront.transform.localPosition, new Vector3(childFrontPos.x, childFrontPos.y, -hit.distance), speed * Time.deltaTime);
            } else {
                childFront.transform.localPosition = Vector3.Lerp(childFront.transform.localPosition, childFrontPos, speed * Time.deltaTime);
            }
        }
    }
}

