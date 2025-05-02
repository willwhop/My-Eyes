using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagersSetActive : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Enemies;
    void Start()
    {
        foreach (GameObject enemy in Enemies) {
            enemy.SetActive(true);
        }
    }
}
