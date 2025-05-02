//Script by Jacob Thorley
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

    //Spawn scary eye object to attach to face
    public void SpawnScaryEyes() {
        scaryObj = Instantiate(scary_EyesPrefab);
        ScaryPositionReset();
    }

    //Spawn cute eyes object to attach to face
    public void SpawnCuteEyes() {
        cuteObj = Instantiate (cute_EyesPrefab);
        CutePositionReset();
    }

    //Reset scary eyes posiotion
    public void ScaryPositionReset() {
        scaryObj.transform.localPosition = new Vector3(scarySpawnPos.position.x, scarySpawnPos.position.y, scarySpawnPos.position.z);
    }

    //Reset cute eyes position
    public void CutePositionReset() {
        cuteObj.transform.localPosition = new Vector3(cuteSpawnPos.position.x, cuteSpawnPos.position.y, cuteSpawnPos.position.z);
    }
}
