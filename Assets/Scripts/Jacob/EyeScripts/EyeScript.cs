using UnityEngine;

public class EyeScript : MonoBehaviour {

    [SerializeField] private GameObject scaryEyes, cuteEyes, eyeFilter, level1Clone, playerAnchor, player, healthBar;
    [SerializeField] private Material pinkFilter, blackFilter, pinkMat, blackMat;

    public bool boolScary, boolCute;

    private void Awake() {
        healthBar = player.transform.GetChild(2).gameObject;
    }

    private void OnTriggerEnter(Collider collider) {
        //check if eyes are in trigger
        if (collider.transform.CompareTag("ScaryEyes")) {
            //set prefab
            scaryEyes = collider.gameObject;
            boolScary = true;
        }
        if (collider.transform.CompareTag("CuteEyes")) {
            //set prefab
            cuteEyes = collider.gameObject;
            boolCute = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
        //check if eyes are out of trigger
        if (collider.transform.CompareTag("ScaryEyes")) {
            boolScary = false;
        }
        if (collider.transform.CompareTag("CuteEyes")) {
            boolCute = false;
        }
    }

    public void OnEyes() {
        if (boolScary == true) {
            //Add scary eyes functionality here

            healthBar.SetActive(true);

            //Hide scary eyes mesh
            scaryEyes.SetActive(false);

            //Debug eye filter
            eyeFilter.GetComponent<Renderer>().enabled = true;
            eyeFilter.GetComponent<Renderer>().material = blackFilter;
        }
        if (boolCute == true) {
            //Add cute eyes funtionality here

            //Hide cute eyes mesh
            cuteEyes.GetComponent<MeshRenderer>().enabled = false;

            //Debug eye filter
            eyeFilter.GetComponent<Renderer>().enabled = true;
            eyeFilter.GetComponent<Renderer>().material = pinkFilter;
        }
    }

    public void OffEyes() {
        //Show eyes mesh
        if (scaryEyes.activeSelf == false && cuteEyes.activeSelf == false) {
            scaryEyes.SetActive(true);
            cuteEyes.SetActive(true);
            //Disable filter
            eyeFilter.GetComponent<Renderer>().enabled = false;
            //Disable scary Health
            healthBar.SetActive(false);
        }
    }
}
