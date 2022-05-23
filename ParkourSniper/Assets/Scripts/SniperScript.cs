using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class SniperScript : MonoBehaviour
{
    //public LineRenderer m_lineRenderer;

    private Camera _cam;
    private Vector2 _rotateInput;
    private bool _isRotating = false;

    public float RotatingSpeed = 1.0f;
    private float angle = 0f;
    private float _sens = 100f;

    public GameObject laser;
    public GameObject UIScope;

    private float currentTime;
    private int shotCount = 0 ;

    //private int percision = 40;

    private LaserListScript LLS;
    // Start is called before the first frame update


    public bool IsRotating { get => _isRotating; set => _isRotating = value; }

    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
        LLS = FindObjectOfType<LaserListScript>();
    }
    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        Rotation();
    }
    public void RotationInput(InputAction.CallbackContext context)
    {
        _rotateInput = context.ReadValue<Vector2>();

        if (context.performed)
            IsRotating = true;

        if (context.canceled)
            IsRotating = false;
    }
    public void ScopeInpute(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _sens = 30f;
            UIScope.SetActive(true);
            _cam.fieldOfView = 20;
        }
        if (context.canceled)
        {
            _sens = 100f;
            UIScope.SetActive(false);
            _cam.fieldOfView = 60;
        }
    }
    public void ShootInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shotCount++;
            Vector3 rayOrigin = _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            //RaycastHit hit;

            LLS.LaserListQueue(_cam.transform.forward, rayOrigin, shotCount * 2);

            Instantiate(laser);
        }
    }

    private void Rotation()
    {
        if (IsRotating)
        {
            if (_rotateInput.x != 0 || _rotateInput.y != 0)
            {
                float angleX = _rotateInput.x * _sens * Time.fixedDeltaTime;
                float angleY = _rotateInput.y * _sens * Time.fixedDeltaTime;

                angle -= angleY;
                angle = Mathf.Clamp(angle, -90f, 90f);

                _cam.transform.localRotation = Quaternion.Euler(angle, 0f, 0f);
                transform.Rotate(Vector3.up * angleX);
            }
        }
    }
}
