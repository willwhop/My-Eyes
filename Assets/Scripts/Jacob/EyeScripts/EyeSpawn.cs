using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeSpawn : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GameObject scary_EyesPrefab, cute_EyesPrefab;
    [SerializeField] private Transform scarySpawnPos, cuteSpawnPos;

    private void Awake() {
        SpawnScaryEyes();
        SpawnCuteEyes();
    }

    public void SpawnScaryEyes() {
        GameObject scaryObj = Instantiate(scary_EyesPrefab);
        scaryObj.transform.position = scarySpawnPos.transform.localPosition;
    }

    public void SpawnCuteEyes() {
        GameObject cuteObj = Instantiate (cute_EyesPrefab);
        cuteObj.transform.position = cuteSpawnPos.transform.localPosition;
    }
}
