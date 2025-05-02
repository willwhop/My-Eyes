//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class SpawnLevel : MonoBehaviour {

    [SerializeField] private GameObject level1Prefab, level2Prefab, level3Prefab, level4Prefab, level5Prefab, level6Prefab, level7Prefab, level8Prefab, player, currentLevelFocus, vRPlayer, levelGrabber, levelSpawnAnchor, rotateAnchor, l1PlayerSpawn, l2PlayerSpawn, l3PlayerSpawn, l4PlayerSpawn, l5PlayerSpawn, l6PlayerSpawn, l7PlayerSpawn, l8PlayerSpawn, dog, moveableNPC1, moveableNPC2, moveableNPC3, moveableNPC4;

    [SerializeField] private Transform level1, level2, level3, level4, level5, level6, level7, level8;

    [SerializeField] private Vector3 lerpScaleMin, lerpScaleMax, lerpPosMin, lerpPosMax;

    [SerializeField] private float lerpSpeed = 1, levelAnchorRot;

    public GameObject playerClone, level1Obj, level2Obj, level3Obj, level4Obj, level5Obj, level6Obj, level7Obj, level8Obj;

    public int levelID = 1;
    private int lerpID;

    [SerializeField] private List<GameObject> unfocusedLevels;

    private void Awake() {
        unfocusedLevels = new List<GameObject>();
        player = GameObject.Find("Player");
        Level1Spawn(); Level2Spawn(); Level3Spawn(); Level4Spawn(); Level5ASpawn(); Level6Spawn(); Level7Spawn(); Level8Spawn();
        l1PlayerSpawn = GameObject.Find("Level1PlayerSpawn");
        l2PlayerSpawn = GameObject.Find("Level2PlayerSpawn");
        l3PlayerSpawn = GameObject.Find("Level3PlayerSpawn");
        l4PlayerSpawn = GameObject.Find("Level4PlayerSpawn");
        l5PlayerSpawn = GameObject.Find("Level5PlayerSpawn");
        l6PlayerSpawn = GameObject.Find("Level6PlayerSpawn");
        l7PlayerSpawn = GameObject.Find("Level7PlayerSpawn");
        l8PlayerSpawn = GameObject.Find("Level8PlayerSpawn");
        moveableNPC1 = GameObject.FindWithTag("MoveNPC1");
        moveableNPC2 = GameObject.FindWithTag("MoveNPC2");
        moveableNPC3 = GameObject.FindWithTag("MoveNPC3");
        moveableNPC4 = GameObject.FindWithTag("MoveNPC4");
    }

    //Instantiate Level 1
    private void Level1Spawn() {
        level1Obj = Instantiate(level1Prefab);
        level1Obj.transform.position = new Vector3(0, 6, 0);
        currentLevelFocus = level1Obj;
    }

    //Instantiate Level 2
    private void Level2Spawn() {
        if (level2 != null && level2Prefab != null) {
            level2Obj = Instantiate(level2Prefab);
            level2Obj.transform.position = level2.transform.position;
            level2Obj.transform.rotation = level2.transform.rotation;
            level2Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level2Obj);
        }
    }

    //Instantiate Level 3
    private void Level3Spawn() {
        if (level3 != null && level3Prefab != null) {
            level3Obj = Instantiate(level3Prefab);
            level3Obj.transform.position = level3.transform.position;
            level3Obj.transform.rotation = level3.transform.rotation;
            level3Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level3Obj);
        }
    }

    //Instantiate Level 4
    private void Level4Spawn() {
        if (level4 != null && level4Prefab != null) {
            level4Obj = Instantiate(level4Prefab);
            level4Obj.transform.position = level4.transform.position;
            level4Obj.transform.rotation = level4.transform.rotation;
            level4Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level4Obj);
        }
    }

    //Instantiate Level 5
    private void Level5ASpawn() {
        if (level5 != null && level5Prefab != null) {
            level5Obj = Instantiate(level5Prefab);
            level5Obj.transform.position = level5.transform.position;
            level5Obj.transform.rotation = level5.transform.rotation;
            level5Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level5Obj);
        }
    }

    //Instantiate Level 6
    private void Level6Spawn() {
        if (level6 != null && level6Prefab != null) {
            level6Obj = Instantiate(level6Prefab);
            level6Obj.transform.position = level6.transform.position;
            level6Obj.transform.rotation = level6.transform.rotation;
            level6Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level6Obj);
        }
    }

    //Instantiate Level 7
    private void Level7Spawn() {
        if (level7 != null && level7Prefab != null) {
            level7Obj = Instantiate(level7Prefab);
            level7Obj.transform.position = level7.transform.position;
            level7Obj.transform.rotation = level7.transform.rotation;
            level7Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level7Obj);
        }
    }

    //Instantiate Level 8
    private void Level8Spawn() {
        if (level8 != null && level8Prefab != null) {
            level8Obj = Instantiate(level8Prefab);
            level8Obj.transform.position = level8.transform.position;
            level8Obj.transform.rotation = level8.transform.rotation;
            level8Obj.transform.localScale = lerpScaleMin;
            unfocusedLevels.Add(level8Obj);
        }
    }

    //parent unfocused levels to anchor
    public void ParentUnfocusedLevels() {
        foreach (GameObject level in unfocusedLevels) {
            if (level != currentLevelFocus) {
                level.transform.parent = rotateAnchor.transform;
            }
        }
    }

    //Unparent unfocused levels from anchor
    public void UnparentUnfocusedLevels() {
        foreach (GameObject level in unfocusedLevels) {
            if (level != currentLevelFocus) {
                level.transform.parent = null;
            }
        }
    }

    private void RotateSpawners() {
        levelSpawnAnchor.transform.localRotation = Quaternion.Euler(0, levelAnchorRot, 0);
    }

    private void Update() {
        //lerp up in scale
        if (lerpID == 1) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, lerpScaleMin, lerpSpeed * Time.deltaTime);
        }
        //Lerp down in scale
        else if (lerpID == 2) {
            currentLevelFocus.transform.localScale = Vector3.Lerp(currentLevelFocus.transform.localScale, lerpScaleMax, lerpSpeed * Time.deltaTime);
        }
    }

    public IEnumerator NextLevelFocus() {
        switch (levelID) {
            //Load Level 1
            case 1:
                //deactivate player
                player.SetActive(false);
            //lerp scale current level down
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
            //change level focus
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level1Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level1Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
            //lerp scale new current level up
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
            //attach VR player anchor to level
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
            //move level rotator to new current level
                levelGrabber.transform.position = level1Obj.transform.position;
            //Rotate the unfocused levels anchor
                RotateSpawners();
                gameObject.transform.position = level1Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
            //set lerp ID to 0
                lerpID = 0;
            //spawn player in new current level
                l1PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l1PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
            //if the dog is in the scene activate it
                if (dog != null) {
                dog.SetActive(true);
                }
                break;
                //Load Level 2
            case 2:
                //if the dog is in the scene deativate it
                if (dog != null) {
                dog = GameObject.Find("Dog");
                dog.SetActive(false);
                 }
                //deactivate player
                player.SetActive(false);
            //lerp scale current level down
            lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
            //change level focus
            unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level2Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level2Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
            //lerp scale new current level up
            lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
            //attach VR player anchor to level
            vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
            //move level rotator to new current level
            levelGrabber.transform.position = level2Obj.transform.position;
            //Rotate the unfocused levels anchor
            RotateSpawners();
                gameObject.transform.position = level2Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
            //Rotate the unfocused levels anchor
                lerpID = 0;
            //spawn player in new current level
                l2PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l2PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
            //Load Level 3
            case 3:
                player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level3Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level3Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level3Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level3Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l3PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l3PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
            //Load Level 4
            case 4:
                player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level4Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level4Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level4Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level4Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l4PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l4PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
            //Load Level 5
            case 5:
                //check moveable NPCs off
            if (moveableNPC1 != null && moveableNPC2 != null && moveableNPC3 != null && moveableNPC4 != null) {
                moveableNPC1.SetActive(false);
                moveableNPC2.SetActive(false);
                moveableNPC3.SetActive(false);
                moveableNPC4.SetActive(false);
            }
            player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level5Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level5Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level5Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level5Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l5PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l5PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
            //Load Level 6
            case 6:
                player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level6Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level6Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level6Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level6Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l6PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l6PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
            //Check moveable NPCs on
            if (moveableNPC1 != null && moveableNPC2 != null && moveableNPC3 != null && moveableNPC4 != null) {
                moveableNPC1.SetActive(true);
                moveableNPC2.SetActive(true);
                moveableNPC3.SetActive(true);
                moveableNPC4.SetActive(true);
            }
                break;
            //Load Level 7
            case 7:
                //Check moveableNPCs off
            if (moveableNPC1 != null && moveableNPC2 != null && moveableNPC3 != null && moveableNPC4 != null) {
                moveableNPC1.SetActive(false);
                moveableNPC2.SetActive(false);
                moveableNPC3.SetActive(false);
                moveableNPC4.SetActive(false);
            }
            player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level7Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level7Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level7Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level7Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l7PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l7PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
            //Load Level 8
            case 8:
                player.SetActive(false);
                lerpID = 1;
                yield return new WaitForSeconds(lerpSpeed);
                unfocusedLevels.Add(currentLevelFocus);
                currentLevelFocus = level8Obj;
                unfocusedLevels.Remove(currentLevelFocus);
                level8Obj.transform.parent = null;
                lerpPosMax.x = currentLevelFocus.transform.position.x;
                lerpPosMax.z = currentLevelFocus.transform.position.z;
                lerpID = 2;
                yield return new WaitForSeconds(lerpSpeed);
                vRPlayer.transform.parent = null;
                levelSpawnAnchor.transform.position = vRPlayer.transform.position;
                levelGrabber.transform.position = level8Obj.transform.position;
                RotateSpawners();
                gameObject.transform.position = level8Obj.transform.position;
                vRPlayer.transform.parent = gameObject.transform;
                lerpID = 0;
                l8PlayerSpawn.GetComponent<SpawnPlayer>().canSpawn = true;
                l8PlayerSpawn.GetComponent<SpawnPlayer>().Spawn();
                player.SetActive(true);
                break;
        }
    }
}