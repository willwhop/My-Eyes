using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enablepause : MonoBehaviour
{
    public GameObject canvas;
    public GameObject playerhead;
    public InputActionReference PauseButton;
    public bool IsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        PauseButton.action.Enable();
    }

    private void OnDisable() {
        PauseButton.action.Disable();
    }

    public void CreateCanvas() {
        canvas.transform.position = playerhead.transform.position + new Vector3 (10,0,0);
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
            if (PauseButton.action.IsPressed()) {
                CreateCanvas();               
            }
        
        
    }
}
