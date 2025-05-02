//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    [SerializeField] private GameObject player;

    public bool canSpawn;

    private void Awake() {
        player = GameObject.Find("Player");
    }

    //player spawn function
    public void Spawn() {
        if (canSpawn == true && player.activeSelf == false) {
            player.transform.position = gameObject.transform.position;
        }
    }
}
