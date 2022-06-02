using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private MenuPauseInput _mPI;
    private InputAction _menu;

    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private bool isPaused;
    // Start is called before the first frame update
    private void Awake()
    {
        _mPI = new MenuPauseInput();
    }
    private void OnEnable()
    {
        _menu = _mPI.PausingMenu.Escape;

        _menu.Enable();
        _menu.performed += Pause;
    }
    private void OnDisable()
    {
        _menu.Disable();
    }
    public void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }

        Debug.Log("hey");
    }


    private void ActivateMenu()
    {
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
        isPaused = false;
    }
}
