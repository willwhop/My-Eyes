using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {
    
    private GameObject playerAnchorRef;
    [SerializeField] private int nextLevelID;

    private void Awake()
    {
        playerAnchorRef = GameObject.Find("PlayerAnchor");
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")){
            playerAnchorRef.GetComponent<SpawnLevel>().levelID = nextLevelID;
            playerAnchorRef.GetComponent<SpawnLevel>().NewLevelFocus();
        }
    }
}
