using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class CreateCubeOnMouseClick : MonoBehaviour
{
    public GameObject cube = null;
    public InputActionReference createActionRef = null;
    public LayerMask groundLayer;
    public float spawnHeightOffset = 0.5f;
    public Joystick joystick = null;
    
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        createActionRef.action.performed += onCreateInputPressed;
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    private void onCreateInputPressed(InputAction.CallbackContext context)
    {
        CreateCube(Input.mousePosition);
    }

    private void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.TouchSimulation.Disable();
        createActionRef.action.performed -= onCreateInputPressed;
    }



    private void OnFingerDown(Finger finger)
    {
        RectTransform joystickRect = (joystick.transform as RectTransform);
        bool xIn = joystickRect.offsetMin.x <= finger.screenPosition.x
            && finger.screenPosition.x <= joystickRect.offsetMax.x;
        bool yIn = joystickRect.offsetMin.y <= finger.screenPosition.y
            && finger.screenPosition.y <= joystickRect.offsetMax.y;

        bool isOnJoystick = xIn && yIn;
        if (!isOnJoystick)
        {
            CreateCube(finger.screenPosition);
        }

    }



    private void CreateCube(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
        {
            Vector3 spawnPoint = hit.point;
            spawnPoint.y += spawnHeightOffset;

            GameObject.Instantiate(cube, spawnPoint, Quaternion.identity);
        }
    }   
}
