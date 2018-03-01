using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class extends base PowerUp and implements it's own effects
public class SpeedUp : PowerUp {

    private float defaultSpeed;
    private float defaultJumpHeight;

    //mulitplies player speed and jump height
    protected override void StartEffect()
    {
        defaultSpeed = playerController.Speed;
        defaultJumpHeight = playerController.JumpForce;

        playerController.Speed = defaultSpeed + playerController.Speed * bonusMultiplier;
        playerController.JumpForce = defaultSpeed + playerController.JumpForce * bonusMultiplier;

        //starts visual and audio effects
        effectAudio.Play();
        effectAnimator.SetBool("dissolve", true);
    }

    //restores default player speed and jump height
    protected override void EndEffect()
    {
        playerController.Speed = defaultSpeed;
        playerController.JumpForce = defaultSpeed;
    }
}
