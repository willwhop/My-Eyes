using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersSetActive : MonoBehaviour
{
    
    public List<GameObject> Enemies;
    void Start()
    {
        //connected to villagers so will set all to active when the game starts.
        foreach (GameObject enemy in Enemies) {
            enemy.SetActive(true);
        }
    }
}
