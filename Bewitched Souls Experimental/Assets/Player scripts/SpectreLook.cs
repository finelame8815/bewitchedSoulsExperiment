using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private GameObject camera;

    public bool active_player;
    private float xAxisClamp;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = camera.GetComponent<Transform>();
        cameraTransform.localRotation = new Quaternion(0, 0, 0, 0);
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            active_player = !active_player;
        camera.GetComponent<Camera>().enabled = active_player;
        transform.GetChild(0).GetComponent<AudioListener>().enabled = active_player;
        GetComponent<PlayerMove>().enabled = active_player;
        int ms = 1;
        if (!active_player)
            ms = 0;
        GetComponent<SpectreLook>().mouseSensitivity = ms * 100;
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
        transform.Rotate(0, mouseX, 0);
        cameraTransform.Rotate(-mouseY, 0, 0);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = cameraTransform.eulerAngles;
        eulerRotation.x = value;
        cameraTransform.eulerAngles = eulerRotation;
    }
}
