using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFlower : MonoBehaviour {

    [SerializeField] private GameObject growIcon, player;
    [SerializeField] private Material transGreen;

    [SerializeField] private float growSpeed;

    Vector3 min = new Vector3(0.001f,0.001f,0.001f), max = new Vector3(1, 1, 1);

    int lerpChoice;

    private void Awake() {
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        StartCoroutine(Grow());
    }
    

    // Update is called once per frame
    private void Update() {
        if (lerpChoice == 1) {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, max, growSpeed * Time.deltaTime);
        }
        else if(lerpChoice == 2){
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, min, growSpeed * Time.deltaTime);
        }
    }

    public IEnumerator Grow() {
        lerpChoice = 1;
        yield return new WaitForSeconds(1.5f);
        lerpChoice = 0;
    }

    public IEnumerator Shrink() {
        lerpChoice = 2;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        lerpChoice = 0;
    }
}
