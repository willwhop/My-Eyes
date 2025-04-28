using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletRollAndDoor : MonoBehaviour {
    public GameObject player;
    public QuestGiverNPC QuestGiver;
    public Rigidbody toiletroll;
    public GameObject door;
    private bool Addforce;
    private bool givenkey;
    // Start is called before the first frame update
    void Start() {
        Addforce = true;
        player = GameObject.FindWithTag("Player");
    }
    private void ToiletRoll() {

        if (QuestGiver.ToiletRollForce == true && Addforce == true) {
            toiletroll.AddForce(0, 0, 10);
            Addforce = false;

        }
        if (Addforce == false) {
            toiletroll.AddForce(0,0,0);
        }
    }
    private void Door() {
        if (QuestGiver.QuestKey.transform.IsChildOf(player.transform)) {
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
    void Update() {
        ToiletRoll();
    }
}
