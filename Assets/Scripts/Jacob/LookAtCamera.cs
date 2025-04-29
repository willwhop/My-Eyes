using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    [SerializeField] private GameObject playerAnchor;

    private void Awake()
    {
        playerAnchor = GameObject.Find("PlayerAnchor");
    }

    void Update() {
        gameObject.transform.LookAt(playerAnchor.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform);
    }
}
