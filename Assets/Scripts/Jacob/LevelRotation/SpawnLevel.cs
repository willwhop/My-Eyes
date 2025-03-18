using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject level1Prefab, level2Prefab, level3Prefab, level4Prefab, level5Prefab, levelRotator, playerPrefab;
    [SerializeField] private Transform level2, level3, level4, level5, level6, l1PlayerSpawn;

    public GameObject playerClone;

    private void Awake() {
        Level1Spawn(); Level2Spawn(); Level3Spawn(); Level4Spawn(); Level5Spawn();
    }

    public void MoveLevelRotator() {
        levelRotator.transform.position = gameObject.transform.position;
    }

    private void Level1Spawn() {
        GameObject level1Obj = Instantiate(level1Prefab);
        level1Obj.transform.position = gameObject.transform.position;
        //PlayerSpawn();
    }

    private void Level2Spawn() {
        GameObject level2Obj = Instantiate(level2Prefab);
        level2Obj.transform.position = level2.transform.position;
        level2Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Level3Spawn() {
        GameObject level3Obj = Instantiate(level3Prefab);
        level3Obj.transform.position = level3.transform.position;
        level3Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Level4Spawn() {
        GameObject level4Obj = Instantiate(level4Prefab);
        level4Obj.transform.position = level4.transform.position;
        level4Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Level5Spawn() {
        GameObject level5Obj = Instantiate(level5Prefab);
        level5Obj.transform.position = level5.transform.position;
        level5Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void PlayerSpawn() {
        playerClone = Instantiate(playerPrefab);
        playerClone.transform.position = l1PlayerSpawn.transform.position;
    }
}
