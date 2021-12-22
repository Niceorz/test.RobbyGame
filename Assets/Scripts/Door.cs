using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    int openId;

    void Start()
    {
        anim = GetComponent<Animator>();
        openId = Animator.StringToHash("Open");
        GameManager.RegisterDoor(this);
    }

    public void Open()
    {
        anim.SetTrigger(openId);
        //play audio
        AudioManager.PlayDoorOpenAudio();
    }
}
