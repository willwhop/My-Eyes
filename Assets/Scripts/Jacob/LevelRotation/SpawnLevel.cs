using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject level1Prefab, level2Prefab, level3Prefab, level4Prefab, level5APrefab, level5BPrefab, levelRotator, playerPrefab, currentLevelFocus;
    [SerializeField] private Transform level1, level2, level3, level4, level5, level6, l1PlayerSpawn;
    [SerializeField] private float lerpSpeed = 1;

    private GameObject level1Obj, level2Obj, level3Obj, level4Obj, level5AObj, level5BObj;

    public GameObject playerClone;

    public int levelID = 1;
    private int lerpID;

    private void Awake() {
        Level1Spawn(); Level2Spawn(); Level3Spawn(); Level4Spawn(); Level5ASpawn(); Level5BSpawn();
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

    private void Update() {
        if (lerpID == 1) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, currentLevelFocus.transform.localScale / 2, 1 * Time.deltaTime);
        }
        else if (lerpID == 2) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, currentLevelFocus.transform.localScale * 2, 1 * Time.deltaTime);
        }
    }

    public IEnumerator NewLevelFocus() {
        switch (levelID) {
            //Load Level 1
            case 1:
            lerpID = 1;
            yield return new WaitForSeconds(1);
            currentLevelFocus = level1Obj;
            lerpID = 2;
            yield return new WaitForSeconds(1);
            lerpID = 0;
                break;
            //Load Level 2
            case 2:
            lerpID = 1;
            yield return new WaitForSeconds(1);
            currentLevelFocus = level2Obj;
            lerpID = 2;
            yield return new WaitForSeconds(1);
            lerpID = 0;
                break;
            //Load Level 3
            case 3:
            lerpID= 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level3Obj;
            lerpID = 2;
                break;
            //Load Level 4
            case 4:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level4Obj;
            lerpID = 2;
                break;
            //Load Level 5
            case 5:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level5AObj;
            lerpID = 2;
                break;
            //Load Level 6
            case 6:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level5AObj;
            lerpID = 2;
                break;
        }
    }
}
