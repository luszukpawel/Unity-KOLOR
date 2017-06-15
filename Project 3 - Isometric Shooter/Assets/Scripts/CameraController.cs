using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform target;

    // Use this for initialization
    private GameObject PlayerTransform;
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = PlayerTransform.transform.position;
    }
}
