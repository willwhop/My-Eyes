using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject levelPrefab, levelRotator;

    private void Awake() {
        GameObject levelObj = Instantiate(levelPrefab);
        levelObj.transform.position = gameObject.transform.position;
    }

    public void MoveLevelRotator() {
        levelRotator.transform.position = gameObject.transform.position;
    }
}
