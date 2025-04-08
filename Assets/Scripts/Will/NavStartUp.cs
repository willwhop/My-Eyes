using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavStartUp : MonoBehaviour
{
    private GameObject dog;
    public GameObject dogbowl;
    public GameObject scrapbot;
    public GameObject[] dogpoints;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        foreach (GameObject point in dogpoints) {
            dog.GetComponent<MovableNPCs>().PatrolPoints.Add(point);
        }
        dog.GetComponent<MovableNPCs>().questscript = scrapbot.GetComponent<QuestGiverNPC>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
