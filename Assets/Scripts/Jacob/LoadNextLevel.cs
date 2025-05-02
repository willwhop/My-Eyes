using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {
    
    private GameObject playerAnchorRef;
    [SerializeField] private int nextLevelID;

    private void Start() {
        playerAnchorRef = GameObject.Find("PlayerAnchor");
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player") && playerAnchorRef.transform.GetChild(0).gameObject != null){
            playerAnchorRef.GetComponent<SpawnLevel>().levelID = nextLevelID;
            playerAnchorRef.GetComponent<SpawnLevel>().StartCoroutine("NextLevelFocus");
        }
    }
}
