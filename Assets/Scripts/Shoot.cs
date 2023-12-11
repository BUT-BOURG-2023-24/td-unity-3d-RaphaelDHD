using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public GameObject impact = null;
    public InputActionReference shootActionRef = null;
    public LayerMask ennemyLayer;
    public LayerMask groundLayer;

    private void OnEnable()
    {
        shootActionRef.action.performed += onShootInputPressed;
    }

    private void onShootInputPressed(InputAction.CallbackContext context)
    {
        ShootAction();
    }

    private void OnDisable()
    {
        shootActionRef.action.performed -= onShootInputPressed;
    }

    private void ShootAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, ennemyLayer))
        {
            Vector3 spawnPoint = hit.point;
            GameObject.Instantiate(impact, spawnPoint, Quaternion.identity);
        }
        else if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
        {
            Vector3 spawnPoint = hit.point;
            GameObject.Instantiate(impact, spawnPoint, Quaternion.identity);
        }
    }

}
