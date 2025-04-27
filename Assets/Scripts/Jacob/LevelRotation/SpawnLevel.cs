using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject level1Prefab, level2Prefab, level3Prefab, level4Prefab, level5Prefab, level6Prefab, level7Prefab, level8Prefab, playerPrefab, currentLevelFocus, vRPlayer, levelGrabber, levelSpawnAnchor;
    [SerializeField] private Transform level1, level2, level3, level4, level5, level6, level7, level8;

    [SerializeField] private Vector3 lerpScaleMin, lerpScaleMax, lerpPosMin, lerpPosMax;

    [SerializeField] private float lerpSpeed = 1, levelAnchorRot;

    private GameObject level2Obj, level3Obj, level4Obj, level5Obj, level6Obj, level7Obj, level8Obj;

    public GameObject playerClone, level1Obj;

    public int levelID = 1;
    private int lerpID;

    [SerializeField] private List<GameObject> unfocusedLevels; 

    private void Awake() {
        unfocusedLevels = new List<GameObject>();
        Level1Spawn(); Level2Spawn(); Level3Spawn(); Level4Spawn(); Level5ASpawn(); Level6Spawn(); Level7Spawn(); Level8Spawn();
    }

    private void Level1Spawn() {
        level1Obj = Instantiate(level1Prefab);
        level1Obj.transform.position = gameObject.transform.position;
        currentLevelFocus = level1Obj;
    }

    private void Level2Spawn() {
        if (level2 != null && level2Prefab != null) {
            level2Obj = Instantiate(level2Prefab);
            level2Obj.transform.position = level2.transform.position;
            level2Obj.transform.rotation = level2.transform.rotation;
            level2Obj.transform.localScale = lerpScaleMin;
            level2Obj.transform.parent = level2;
            unfocusedLevels.Add(level2Obj);
        }
    }

    private void Level3Spawn() {
        if (level3 != null && level3Prefab != null) {
            level3Obj = Instantiate(level3Prefab);
            level3Obj.transform.position = level3.transform.position;
            level3Obj.transform.rotation = level3.transform.rotation;
            level3Obj.transform.localScale = lerpScaleMin;
            level3Obj.transform.parent = level3;
            unfocusedLevels.Add(level3Obj);
        }
    }

    private void Level4Spawn() {
        if (level4 != null && level4Prefab != null) {
            level4Obj = Instantiate(level4Prefab);
            level4Obj.transform.position = level4.transform.position;
            level4Obj.transform.rotation = level4.transform.rotation;
            level4Obj.transform.localScale = lerpScaleMin;
            level4Obj.transform.parent = level4;
            unfocusedLevels.Add(level4Obj);
        }
    }

    private void Level5ASpawn() {
        if (level5 != null && level5Prefab != null) {
            level5Obj = Instantiate(level5Prefab);
            level5Obj.transform.position = level5.transform.position;
            level5Obj.transform.rotation = level5.transform.rotation;
            level5Obj.transform.localScale = lerpScaleMin;
            level5Obj.transform.parent = level5;
            unfocusedLevels.Add(level5Obj);
        }
    }
    private void Level6Spawn() {
        if (level6 != null && level6Prefab != null) {
            level6Obj = Instantiate(level6Prefab);
            level6Obj.transform.position = level6.transform.position;
            level6Obj.transform.rotation = level6.transform.rotation;
            level6Obj.transform.localScale = lerpScaleMin;
            level6Obj.transform.parent = level6;
            unfocusedLevels.Add(level6Obj);
        }
    }

    private void Level7Spawn() {
        if (level7 != null && level7Prefab != null) {
            level7Obj = Instantiate(level7Prefab);
            level7Obj.transform.position = level7.transform.position;
            level7Obj.transform.rotation = level7.transform.rotation;
            level7Obj.transform.localScale = lerpScaleMin;
            level7Obj.transform.parent = level7;
            unfocusedLevels.Add(level7Obj);
        }
    }

    private void Level8Spawn() {
        if (level8 != null && level8Prefab != null) {
            level8Obj = Instantiate(level8Prefab);
            level8Obj.transform.position = level8.transform.position;
            level8Obj.transform.rotation = level8.transform.rotation;
            level8Obj.transform.localScale = lerpScaleMin;
            level8Obj.transform.parent = level8;
            unfocusedLevels.Add(level8Obj);
        }
    }

    private void RotateSpawners() {
        levelSpawnAnchor.transform.Rotate(0, levelAnchorRot, 0);
    }

    private void Update() {
        if (lerpID == 1) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, lerpScaleMin, lerpSpeed * Time.deltaTime);
            currentLevelFocus.transform.position = Vector3.Lerp(currentLevelFocus.transform.position, lerpPosMin, lerpSpeed * Time.deltaTime);
        }
        else if (lerpID == 2) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, lerpScaleMax, lerpSpeed * Time.deltaTime);
            currentLevelFocus.transform.position = Vector3.Lerp(currentLevelFocus.transform.position, lerpPosMax, lerpSpeed * Time.deltaTime);
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
            GameObject.Find("Player").SetActive(false);
            GameObject.Find("Dog").SetActive(false);
            lerpID = 1;
            yield return new WaitForSeconds(lerpSpeed);
            unfocusedLevels.Add(currentLevelFocus);
            level1Obj.transform.parent = level1;
            currentLevelFocus = level2Obj;
            unfocusedLevels.Remove(currentLevelFocus);
            level2Obj.transform.parent = null;
            lerpPosMax.x = currentLevelFocus.transform.position.x;
            lerpPosMax.z = currentLevelFocus.transform.position.z;
            lerpID = 2;
            yield return new WaitForSeconds(lerpSpeed);
            vRPlayer.transform.parent = null;
            RotateSpawners();
            gameObject.transform.position = level2Obj.transform.position;
            vRPlayer.transform.parent = gameObject.transform;
            levelGrabber.transform.position = level2Obj.transform.position;
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
            currentLevelFocus = level5Obj;
            lerpID = 2;
                break;
            //Load Level 6
            case 6:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level6Obj;
            lerpID = 2;
                break;
            //Load Level 7
            case 7:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level7Obj;
            lerpID = 2;
            break;
            //Load Level 8
            case 8:
            lerpID = 1;
            yield return new WaitForSeconds(2);
            currentLevelFocus = level8Obj;
            lerpID = 2;
            break;
        }
    }
}
