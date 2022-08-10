using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    [Header("Camera")]
    public float sensX;
    public float sensY;
    public Camera cam;

    float xRotate;
    float yRotate;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        float mousex = Input.GetAxis("Mouse X") * time * sensX;
        float mousey = Input.GetAxis("Mouse Y") * time * sensY;
        yRotate += mousex;
        xRotate -= mousey;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
    }
}
