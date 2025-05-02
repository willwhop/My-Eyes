using UnityEngine;
using UnityEngine.InputSystem;
//Made by William Hopton
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
        //set raycast from hands active and the canvas. also anchors canvas to player cam
        canvas.transform.position = menuAnchor.transform.position;
        canvas.transform.LookAt(cam.transform);
        handCast.SetActive(true);
        // stops time
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
    //callsback the pausebutton to see if it was pressed
    private void PauseButtonPressed(InputAction.CallbackContext callback) {
        CreateCanvas();
    }
}
