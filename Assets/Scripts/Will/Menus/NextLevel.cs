using UnityEngine;
using UnityEngine.SceneManagement;

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
