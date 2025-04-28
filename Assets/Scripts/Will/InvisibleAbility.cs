using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvisibleAbility : MonoBehaviour
{
    public SpriteRenderer PlayerSpriteRender;
    public bool isInVisible;
    public InputAction InvisButton;
    private float timer;
    public bool CanTurnInvis;
    // Start is called before the first frame update
    void Start()
    {
        isInVisible = false;
        CanTurnInvis = true;
    }
    private void Invisible() {
        PlayerSpriteRender.color = new Color(PlayerSpriteRender.color.r, PlayerSpriteRender.color.g, PlayerSpriteRender.color.b, 84);
    }
    private void Visible() {
        PlayerSpriteRender.color = new Color(PlayerSpriteRender.color.r, PlayerSpriteRender.color.g, PlayerSpriteRender.color.b, 255);
    }
    // Update is called once per frame
    void Update()
    {        
        if (isInVisible == true) {
            Invisible();
            timer += Time.deltaTime;
            if (timer >= 4 && timer < 5) {
                isInVisible = false;
                Visible();
            }            
        }
        if (isInVisible == false) {
            timer += Time.deltaTime;
            if (timer >= 10) {
                timer = 0;
                CanTurnInvis = true;
            }
        }
    }
}
