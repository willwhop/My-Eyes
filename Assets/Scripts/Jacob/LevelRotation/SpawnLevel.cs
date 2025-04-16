using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject level1Prefab, level2Prefab, level3Prefab, level4Prefab, level5APrefab, level5BPrefab, levelRotator, playerPrefab, currentLevelFocus;
    [SerializeField] private Transform level2, level3, level4, level5, level6, l1PlayerSpawn;
    [SerializeField] private float lerpSpeed = 1;

    private GameObject level1Obj, level2Obj, level3Obj, level4Obj, level5AObj, level5BObj;

    public GameObject playerClone;

    public int levelID = 1;
    private float lerpDown, lerpUp;
    private int lerpID;

    private void Awake() {
        Level1Spawn(); Level2Spawn(); Level3Spawn(); Level4Spawn(); Level5ASpawn(); Level5BSpawn();
        lerpUp = Mathf.Lerp(1f, 0.5f, lerpSpeed * Time.deltaTime);
        lerpDown = Mathf.Lerp(0.5f, 1f, lerpSpeed * Time.deltaTime);
    }

    public void MoveLevelRotator() {
        levelRotator.transform.position = gameObject.transform.position;
    }

    private void Level1Spawn() {
        level1Obj = Instantiate(level1Prefab);
        level1Obj.transform.position = gameObject.transform.position;
        currentLevelFocus = level1Obj;
    }

    private void Level2Spawn() {
        level2Obj = Instantiate(level2Prefab);
        level2Obj.transform.position = level2.transform.position;
        level2Obj.transform.rotation = level2.transform.rotation;
        level2Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        level2Obj.transform.parent = level2;
    }

    private void Level3Spawn() {
        level3Obj = Instantiate(level3Prefab);
        level3Obj.transform.position = level3.transform.position;
        level3Obj.transform.rotation = level3.transform.rotation;
        level3Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        level3Obj.transform.parent = level3;
    }

    private void Level4Spawn() {
        level4Obj = Instantiate(level4Prefab);
        level4Obj.transform.position = level4.transform.position;
        level4Obj.transform.rotation = level4.transform.rotation;
        level4Obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        level4Obj.transform.parent = level4;
    }

    private void Level5ASpawn() {
        level5AObj = Instantiate(level5APrefab);
        level5AObj.transform.position = level5.transform.position;
        level5AObj.transform.rotation = level5.transform.rotation;
        level5AObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        level5AObj.transform.parent = level5;
    }
    private void Level5BSpawn()
    {
        level5BObj = Instantiate(level5BPrefab);
        level5BObj.transform.position = level6.transform.position;
        level5BObj.transform.rotation = level6.transform.rotation;
        level5BObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        level5BObj.transform.parent = level6;
    }

    //public void PlayerSpawn() {
    //    playerClone = Instantiate(playerPrefab);
    //    playerClone.transform.position = l1PlayerSpawn.transform.position;
    //}

    private void Update() {
        if (lerpID == 1) {
            currentLevelFocus.transform.localScale = new Vector3(lerpDown, lerpDown, lerpDown);
        }
        else if (lerpID == 2) {
            currentLevelFocus.transform.localScale = new Vector3(lerpUp, lerpUp, lerpUp);
        }
    }

    public void NewLevelFocus() {
        switch (levelID) {
            case 1:
                StartCoroutine(WaitBetweenLevels());
                currentLevelFocus = level1Obj;
                lerpID = 2;
                break;
            case 2:
                StartCoroutine(WaitBetweenLevels());
                currentLevelFocus = level2Obj;
                lerpID = 2;
                break;
            case 3:
                currentLevelFocus.transform.localScale = new Vector3(lerpDown, lerpDown, lerpDown);
                currentLevelFocus = level3Obj;
                currentLevelFocus.transform.localScale = new Vector3(lerpUp, lerpUp, lerpUp);
                break;
            case 4:
                currentLevelFocus.transform.localScale = new Vector3(lerpDown, lerpDown, lerpDown);
                currentLevelFocus = level4Obj;
                currentLevelFocus.transform.localScale = new Vector3(lerpUp, lerpUp, lerpUp);
                break;
            case 5:
                currentLevelFocus.transform.localScale = new Vector3(lerpDown, lerpDown, lerpDown);
                currentLevelFocus = level5AObj;
                currentLevelFocus.transform.localScale = new Vector3(lerpUp, lerpUp, lerpUp);
                break;
            case 6:
                currentLevelFocus.transform.localScale = new Vector3(lerpDown, lerpDown, lerpDown);
                currentLevelFocus = level5AObj;
                currentLevelFocus.transform.localScale = new Vector3(lerpUp, lerpUp, lerpUp);
                break;
        }
    }

    private IEnumerator WaitBetweenLevels() {
        lerpID = 1;
        yield return new WaitForSeconds(2);
    }
}
