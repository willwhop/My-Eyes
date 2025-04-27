using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CheckIfCanGrow : MonoBehaviour {

    [SerializeField] private GameObject growIcon, player;
    [SerializeField] private Material transRed, transGreen;

    public bool canGrow = false;

    private void OnTriggerStay(Collider other) {
        if (other || player.GetComponent<CharacterMovement>().grounded == false) {
            canGrow = false;
            growIcon.GetComponent<Renderer>().material = transRed;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other && player.GetComponent<CharacterMovement>().grounded == true) {
            canGrow = true;
            growIcon.GetComponent<Renderer>().material = transGreen;
        }
    }

    public void ShowGrowIcon() {
        growIcon.GetComponent<Renderer>().enabled = true;
    }

    public void HideGrowIcon() {
        growIcon.GetComponent<Renderer>().enabled = false;
    }
}
