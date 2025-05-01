using UnityEngine;

public class EnableNextLevel : MonoBehaviour
{
    private GameObject canvas, menuAnchor, cam, handCast;

    private void Start() {
        canvas = GameObject.Find("Continue to next level");
        canvas = GameObject.Find("MenuAnchor");
        canvas = GameObject.Find("Main Camera");
        canvas = GameObject.Find("MenuRayInteractor");
    }
    private void OnCollisionEnter(Collision collision) {
        CreateCanvas();
    }
    private void CreateCanvas() {
        canvas.transform.position = menuAnchor.transform.position;
        canvas.transform.LookAt(cam.transform);
        handCast.SetActive(true);
        Time.timeScale = 0;
        canvas.SetActive(true);
    }
}
