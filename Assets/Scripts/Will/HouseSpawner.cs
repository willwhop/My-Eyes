using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    private float timer = 0;
    public GameObject MovingNPCPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer >= 10f) {
            Instantiate(MovingNPCPrefab, gameObject.transform);
            timer = 0;
        }
        
    }
}
