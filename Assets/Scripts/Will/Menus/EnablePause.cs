using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enablepause : MonoBehaviour
{
    public GameObject canvas, menuAnchor, cam, handCast;
    public InputActionReference PauseButton;
    public bool IsPaused = false;

    private void OnEnable() {
        PauseButton.action.started += PauseButtonPressed;
    }

    private void OnDisable() {
        PauseButton.action.started -= PauseButtonPressed;
    }

    private void CreateCanvas() {
        canvas.transform.position = menuAnchor.transform.position;
        canvas.transform.LookAt(cam.transform);
        handCast.SetActive(true);
        Time.timeScale = 0;
        canvas.SetActive(true);
    }

    private void PauseButtonPressed(InputAction.CallbackContext callback) {
        CreateCanvas();
    }
}
