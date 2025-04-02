using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer : MonoBehaviour
{
    private Camera theCamera;
    public Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        theCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            theCamera.enabled = !theCamera.enabled;
            Cam.enabled = !Cam.enabled;
        }

    }
}
