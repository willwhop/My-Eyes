using UnityEngine;

public class EyeScript : MonoBehaviour {

    [SerializeField] private GameObject scaryEyes, cuteEyes, eyeFilter, level1Clone, playerAnchor, player, healthBar, growIcon;
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

            healthBar.gameObject.SetActive(true);

            //Hide scary eyes mesh
            scaryEyes.GetComponent<MeshRenderer>().enabled = false;

            //Debug eye filter
            eyeFilter.GetComponent<Renderer>().enabled = true;
            eyeFilter.GetComponent<Renderer>().material = blackFilter;
        }
        if (boolCute == true) {
            //Add cute eyes funtionality here
            growIcon.SetActive(true);

            //Hide cute eyes mesh
            cuteEyes.GetComponent<MeshRenderer>().enabled = false;

            //Debug eye filter
            eyeFilter.GetComponent<Renderer>().enabled = true;
            eyeFilter.GetComponent<Renderer>().material = pinkFilter;
        }
    }

    public void OffEyes() {
        //Show eyes mesh
        scaryEyes.GetComponent<MeshRenderer>().enabled = true;
        cuteEyes.GetComponent<MeshRenderer>().enabled = true;
        //Disable filter
        eyeFilter.GetComponent<Renderer>().enabled = false;
        //Disable scary Health
        if (healthBar != null) {
            healthBar.SetActive(false);
        }
        //Disable growIcon Mesh
        if (growIcon != null) {
            growIcon.SetActive(false);
        }
    }
}
