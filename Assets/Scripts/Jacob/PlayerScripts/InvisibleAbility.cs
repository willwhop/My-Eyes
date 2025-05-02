//Script by Jacob Thorley
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvisibleAbility : MonoBehaviour {
    public bool isInVisible;
    public bool CanTurnInvis;
    [SerializeField] private int invisDuration, invisCooldown;
    [SerializeField] private GameObject PlayerSprite, transSprite;
    [SerializeField] private AudioClip invisClip, visClip;

    AudioSource source;

    // Start is called before the first frame update
    void Start() {
        source = gameObject.GetComponent<AudioSource>();
        isInVisible = false;
        CanTurnInvis = true;
    }

    //turn invis function
    private void Invisible() {
        PlayerSprite.SetActive(false);
        transSprite.SetActive(true);
    }

    //change back to visible function
    private void Visible() {
        PlayerSprite.SetActive(true);
        transSprite.SetActive(false);
    }

    //Invisible duration and cooldown
    public IEnumerator turnInvis() {
        if (CanTurnInvis == true) {
            source.PlayOneShot(invisClip);
            CanTurnInvis = false;
            isInVisible = true;
            Invisible();
            yield return new WaitForSeconds(invisDuration);
            Visible();
            isInVisible = false;
            source.PlayOneShot(visClip);
            yield return new WaitForSeconds(invisCooldown);
            CanTurnInvis = true;
        }
    }
}
