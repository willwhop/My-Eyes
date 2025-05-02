using UnityEngine;
//Made by William Hopton
public class EnableNextLevel : MonoBehaviour {
    [SerializeField] private GameObject canvas, menuAnchor, cam, handCast, playerAnchor, finishLevel, questGiver;

    private void Start() {
        questGiver = GameObject.FindWithTag("NPC1");
        // worked on with jacob. makes trigger boxs go to the specifed levels and the locations on where they should be in scene
        if (questGiver.GetComponent<QuestGiverNPC>().gameObject.name == "CareTaker") {
            finishLevel = GameObject.Find("Level5-AWithAnchor(Clone)");
            gameObject.transform.parent = finishLevel.transform;
            gameObject.transform.localPosition = new Vector3(-0.78f, -5.86f, 1.19f);
            gameObject.transform.localScale = new Vector3(1.9f, 0.5f, 1.5f);
            gameObject.transform.localRotation = Quaternion.identity;
        }
        else if (questGiver.GetComponent<QuestGiverNPC>().gameObject.name != "CareTaker" && questGiver.GetComponent<QuestGiverNPC>().gameObject.name != null) {
            finishLevel = GameObject.Find("Level6WithAnchor(Clone)");
            gameObject.transform.parent = finishLevel.transform;
            gameObject.transform.localPosition = new Vector3(0.333f, 5.87f, 2.141f);
            gameObject.transform.localScale = new Vector3(4.9548f, 1, 3.1116f);
            gameObject.transform.localRotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider collision) {
        //on enter if player set canvas and hand cast to active
        if (collision.CompareTag("Player") && canvas != null && handCast != null) {
            canvas.SetActive(true);
            handCast.SetActive(true);
            canvas.transform.position = menuAnchor.transform.position;
            canvas.transform.LookAt(cam.transform);
            Time.timeScale = 0;
        }
    }
}
