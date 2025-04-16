using UnityEngine;

public class EyeScript : MonoBehaviour
{

    [SerializeField] private GameObject scaryEyes, cuteEyes, eyeFilter, level1Clone, playerAnchor, playerChar;
    [SerializeField] private Material pinkFilter, blackFilter, pinkMat, blackMat, originalMat;
    bool boolScary, boolCute;

    private void OnTriggerEnter(Collider collider)
    {
        //check if eyes are in trigger
        if (collider.transform.CompareTag("ScaryEyes"))
        {
            //set prefab
            scaryEyes = collider.gameObject;
            boolScary = true;
        }
        if (collider.transform.CompareTag("CuteEyes"))
        {
            //set prefab
            cuteEyes = collider.gameObject;
            boolCute = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //check if eyes are out of trigger
        if (collider.transform.CompareTag("ScaryEyes"))
        {
            boolScary = false;
        }
        if (collider.transform.CompareTag("CuteEyes"))
        {
            boolCute = false;
        }
    }

    public void OnEyes()
    {
        if (boolScary == true)
        {
            //Add scary eyes functionality here

            playerChar.transform.GetChild(2).gameObject.SetActive(true);

            //Hide scary eyes mesh
            scaryEyes.GetComponent<MeshRenderer>().enabled = false;

            //Debug eye filter
            eyeFilter.gameObject.SetActive(enabled = true);
            eyeFilter.GetComponent<Renderer>().material = blackFilter;
        }
        if (boolCute == true)
        {
            //Add cute eyes funtionality here

            //Hide cute eyes mesh
            cuteEyes.GetComponent<MeshRenderer>().enabled = false;

            //Debug eye filter
            eyeFilter.gameObject.SetActive(enabled = true);
            eyeFilter.GetComponent<Renderer>().material = pinkFilter;
        }
    }

    public void OffEyes()
    {
        //Show eyes mesh
        scaryEyes.GetComponent<MeshRenderer>().enabled = true;
        cuteEyes.GetComponent<MeshRenderer>().enabled = true;
        //Disable filter
        eyeFilter.gameObject.SetActive(enabled = false);
        //Disable scary Health
        if (playerChar != null)
        {
            playerChar.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
