using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject Canvas;
    void Start() {

    }
    public void continues(){
        Canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Quit() {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
