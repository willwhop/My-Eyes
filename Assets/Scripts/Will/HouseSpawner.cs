using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    private float timer = 0;
    public GameObject MovingNPCPrefab;
    private GameObject[] NPCAmount;
    void Start()
    {
        NPCAmount = GameObject.FindGameObjectsWithTag("MovingNPCs");
    }
    // Update is called once per frame
    void Update()
    {
        if (NPCAmount.Length >= 10) {

        }
        timer += Time.deltaTime;
        if (NPCAmount.Length <= 10) {
            if (timer >= 10f) {
                Instantiate(MovingNPCPrefab, gameObject.transform);
                timer = 0;
            }
        }
    }
}
