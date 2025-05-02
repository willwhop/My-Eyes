using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToiletRollAndDoor : MonoBehaviour {
    public GameObject player, Canvas, handCast;
    public QuestGiverNPC QuestGiver;
    public Rigidbody toiletroll;
    public GameObject door, tP, tPTrigger;
    private bool Addforce;
    private bool givenkey;
    // Start is called before the first frame update
    void Start() {
        Addforce = true;
        player = GameObject.FindWithTag("Player");
        Canvas = GameObject.FindWithTag("Canvas2.0");
        handCast = GameObject.Find("MenuRayInteractor");
    }
    public IEnumerator ToiletRoll() {
        if (toiletroll != null) {
            toiletroll.constraints = RigidbodyConstraints.None;
            if (Addforce == true) {
                toiletroll.AddForce(0, 0, 5);
                Addforce = false;

            }
            if (Addforce == false) {
                toiletroll.AddForce(0, 0, 0);
            }
            yield return new WaitForSeconds(1.5f);
            Destroy(toiletroll);
            tPTrigger.SetActive(true);
            tP.transform.parent = tPTrigger.transform;
        }
    }
    private void Door() {
        if (QuestGiver.QuestKey.transform.IsChildOf(player.transform)) {
            Destroy(door);
            Destroy(QuestGiver.QuestKey);
        }
        else if (QuestGiver.DumpsterBotQuestKey.transform.IsChildOf(player.transform)) {
            Destroy(door);
            Destroy(QuestGiver.DumpsterBotQuestKey);
        }
    }
    private void OnTriggerEnter(Collider other) {
       
        if (other.CompareTag("Player")) {
            if (gameObject.CompareTag("DoorTP")) {
                Door();
            }
        }
    }
}
