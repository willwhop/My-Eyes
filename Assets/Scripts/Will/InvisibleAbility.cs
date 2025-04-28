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

    // Start is called before the first frame update
    void Start() {
        isInVisible = false;
        CanTurnInvis = true;
    }
    private void Invisible() {
        PlayerSprite.SetActive(false);
        transSprite.SetActive(true);
    }
    private void Visible() {
        PlayerSprite.SetActive(true);
        transSprite.SetActive(false);
    }

    public IEnumerator turnInvis() {
        if (CanTurnInvis == true) {
            CanTurnInvis = false;
            isInVisible = true;
            Invisible();
            yield return new WaitForSeconds(invisDuration);
            Visible();
            isInVisible = false;
            yield return new WaitForSeconds(invisCooldown);
            CanTurnInvis = true;
        }
    }
}
