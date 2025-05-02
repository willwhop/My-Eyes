//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    private GameObject playerAnchor;

    private void Awake() {
        playerAnchor = GameObject.Find("PlayerAnchor");
    }

    //always looks at camera, made to be modular
    void Update() {
        gameObject.transform.LookAt(playerAnchor.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform);
    }
}
