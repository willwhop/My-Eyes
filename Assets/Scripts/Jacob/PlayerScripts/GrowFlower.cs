//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowFlower : MonoBehaviour {

    [SerializeField] private GameObject growIcon, player;
    [SerializeField] private Material transGreen;

    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    [SerializeField] private float growSpeed;

    Vector3 min = new Vector3(0.001f,0.001f,0.001f), max = new Vector3(1.5f, 1.5f, 1.5f);

    int lerpChoice;

    private void Awake() {
        source = GameObject.Find("Player").GetComponent<AudioSource>();
        gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        StartCoroutine(Grow());
    }
    

    // Update is called once per frame
    private void Update() {
        //lerp flower scale up
        if (lerpChoice == 1) {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, max, growSpeed * Time.deltaTime);
        }
        //lerp flower scale down
        else if(lerpChoice == 2){
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, min, growSpeed * Time.deltaTime);
        }
    }

    //Grow function
    public IEnumerator Grow() {
        lerpChoice = 1;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(1.5f);
        lerpChoice = 0;
    }

    //Shrink function
    public IEnumerator Shrink() {
        lerpChoice = 2;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        lerpChoice = 0;
    }
}
