using UnityEngine;

public class NavStartUp : MonoBehaviour
{
    private GameObject dog;
    public GameObject dogbowl;
    public GameObject scrapbot;
    public Transform[] dogpoints;

    // on start find dog and add patrol points to it
    void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        foreach (Transform point in dogpoints) {
            dog.GetComponent<MovableNPCs>().PatrolPoints.Add(point);
        }
        dog.GetComponent<MovableNPCs>().questscript = scrapbot.GetComponent<QuestGiverNPC>();
    }    
}
