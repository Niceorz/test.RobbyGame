using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMoveMent movenment;
    Rigidbody2D rb;

    int groundId;
    int crouchId;
    int hangingId;
    int speedId;
    int fallId;

    void Start()
    {
        anim = GetComponent<Animator>();
        movenment = GetComponentInParent<PlayerMoveMent>();
        rb = GetComponentInParent<Rigidbody2D>();

        groundId = Animator.StringToHash("isOnGround");
        crouchId = Animator.StringToHash("isCrouching");
        hangingId = Animator.StringToHash("isHanging");
        speedId = Animator.StringToHash("speed");
        fallId = Animator.StringToHash("verticalVelocity");
    }

    void Update()
    {
        anim.SetFloat(speedId, Mathf.Abs(movenment.xVelocity));
        //anim.SetBool("isOnGround", movenment.isOnGround);
        anim.SetBool(groundId, movenment.isOnGround);
        anim.SetBool(crouchId, movenment.isCrouch);
        anim.SetBool(hangingId, movenment.isHanging);
        anim.SetFloat(fallId, rb.velocity.y);
    }

    public void StepAudio()
    {
        AudioManager.PlayFootstepAudio();
    }

    public void CrouchStepAudio()
    {
        AudioManager.PlayCrouchFootstepAudio();
    }

}
