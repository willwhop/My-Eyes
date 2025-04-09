using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class PlayerHealthScript : MonoBehaviour {

    [SerializeField] private int health = 3;
    [SerializeField] private AudioClip gainHealth, loseHealth;
    private AudioSource source;
    public Transform currentPlayerSpawn;

    private void Awake() {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void LoseHealth() {
        health--;
        source.PlayOneShot(loseHealth);
        CheckHP();
        if (health <= 0) {
            StartCoroutine(Dead());
        }
    }
     public void GainHealth() {
        health++;
        source.PlayOneShot(gainHealth);
        CheckHP();
        if(health >= 3) {
            health = 3;
        }
     }

    private void CheckHP() {
        switch (health) {
            case 0:
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case 1:
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
                break;
            case 3:
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = true;
                break;
        }
    }

    public IEnumerator Dead() {
        //GetComponent<CharacterMovement>().enabled = false;
        //GetComponent<Renderer>().enabled = false;
        Debug.Log("YOU ARE DEAD NOW WAIT FOR 5 SECONDS");
        yield return new WaitForSeconds(5);
        Debug.Log("YOU HAVE WAITED FOR 5 SECONDS WELCOME BACK TO THE LAND OF THE LIVING!");
        //gameObject.transform.position = currentPlayerSpawn.transform.position;
        //GetComponent<Renderer>().enabled = true;
        //GetComponent<CharacterMovement>().enabled = true;
    }









    ////////////////////////////////////////////////////////////////////////////////////////////////// DEBUG INPUTS TO BE DELETED LATER
    private void Update()
    {
        if (Input.GetKeyDown("space")) {
            LoseHealth();
        }
        if (Input.GetKeyDown("j")) {
            GainHealth();
        }
    }
}
