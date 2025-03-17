using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [Header("Beginning Level Prefab Reference")]
    [SerializeField] private GameObject levelPrefab;

    private void Awake() {
        GameObject levelObj = Instantiate(levelPrefab);
        levelObj.transform.position = gameObject.transform.position;
    }

}
