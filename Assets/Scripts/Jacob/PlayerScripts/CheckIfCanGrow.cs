using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfCanGrow : MonoBehaviour {

    [SerializeField] private GameObject growIcon, player;
    [SerializeField] private Material transRed, transGreen;

    public bool canGrow;

    private void OnTriggerEnter(Collider other) {
        canGrow = false;
        growIcon.GetComponent<Renderer>().material = transRed;
    }

    private void OnTriggerExit(Collider other) {
        if (player.GetComponent<CharacterMovement>().grounded == true) {
            canGrow = true;
            growIcon.GetComponent<Renderer>().material = transGreen;
        }
    }
}
