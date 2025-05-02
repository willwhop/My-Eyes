//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CheckIfCanGrow : MonoBehaviour {

    [SerializeField] private GameObject growIcon, player;
    [SerializeField] private Material transRed, transGreen;

    public bool canGrow = false;

    //if it collides with game object, player cannot spawn flower
    private void OnTriggerStay(Collider other) {
        if (other || player.GetComponent<CharacterMovement>().grounded == false) {
            canGrow = false;
            growIcon.GetComponent<Renderer>().material = transRed;
        }
    }

    //On exit of collider and the player is grounded on growable ground, the player can grow flowers again.
    private void OnTriggerExit(Collider other) {
        if (other && player.GetComponent<CharacterMovement>().grounded == true) {
            canGrow = true;
            growIcon.GetComponent<Renderer>().material = transGreen;
        }
    }

    //show grow icon
    public void ShowGrowIcon() {
        growIcon.GetComponent<Renderer>().enabled = true;
    }

    //hide grow icon
    public void HideGrowIcon() {
        growIcon.GetComponent<Renderer>().enabled = false;
    }
}
