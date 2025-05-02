using UnityEngine;
using UnityEngine.SceneManagement;
//Made by William Hopton
public class NextLevel : MonoBehaviour { 

    public void NextArea() {
        SceneManager.LoadScene("Area2");
    }
    public void EndGame() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() {
        Application.Quit();
    }
}
