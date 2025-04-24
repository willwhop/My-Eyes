using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeSpawn : MonoBehaviour {

    [SerializeField] private GameObject scary_EyesPrefab, cute_EyesPrefab, scaryObj, cuteObj;
    [SerializeField] private Transform scarySpawnPos, cuteSpawnPos;

    private void Awake() {
        SpawnScaryEyes();
        SpawnCuteEyes();
    }

    public void SpawnScaryEyes() {
        scaryObj = Instantiate(scary_EyesPrefab);
        ScaryPositionReset();
    }

    public void SpawnCuteEyes() {
        cuteObj = Instantiate (cute_EyesPrefab);
        CutePositionReset();
    }

    public void ScaryPositionReset() {
        scaryObj.transform.position = new Vector3(scarySpawnPos.position.x, scarySpawnPos.position.y, scarySpawnPos.position.z);
    }

    public void CutePositionReset() {
        cuteObj.transform.position = new Vector3(cuteSpawnPos.position.x, cuteSpawnPos.position.y, cuteSpawnPos.position.z);
    }
}
