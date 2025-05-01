using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject Canvas, handCast;
   
    public void NextArea() {
        SceneManager.LoadScene("Area2");
    }
    public void EndGame() {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quit() {
        Application.Quit();
    }
}
