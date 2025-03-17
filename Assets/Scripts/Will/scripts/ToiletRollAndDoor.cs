using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletRollAndDoor : MonoBehaviour
{
    public Transform player;
    public QuestGiverNPC QuestGiver;
    public Rigidbody toiletroll;
    public GameObject door;
    private bool Addforce;
    private bool givenkey;
    // Start is called before the first frame update
    void Start()
    {
        Addforce = true;
    }
    private void ToiletRoll() {
        
        if (QuestGiver.ToiletRollForce == true && Addforce == true) {
            toiletroll.AddForce(0, 0, 10);
            Addforce = false;

        }
    }
    private void Door() {
        if (QuestGiver.QuestKey.transform.IsChildOf(player)) {
            Destroy(door);
        }        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("shshhsjsjs");
        if (other.CompareTag("playerCharacter")) {
            if (gameObject.CompareTag("Door")) {
                Door();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {        
        ToiletRoll();
    }
}
