using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour
{
    //private Vector3 targetPos;
    private Quaternion targetRot;
    private void Start()
    {
        //targetPos = transform.position;
        targetRot = transform.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (SimpleInput.GetAxis("Reset") > 0) {
            //transform.position = targetPos;
            transform.rotation = targetRot;
        }
    }
}
