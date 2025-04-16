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
    public Transform[] dogpoints;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        foreach (Transform point in dogpoints) {
            dog.GetComponent<MovableNPCs>().PatrolPoints.Add(point);
        }
        dog.GetComponent<MovableNPCs>().questscript = scrapbot.GetComponent<QuestGiverNPC>();
    }

    
}
