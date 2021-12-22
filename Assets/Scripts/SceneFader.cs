using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    Animator anim;
    int faderId;

    private void Start()
    {
        anim = GetComponent<Animator>();

        faderId = Animator.StringToHash("Fade");

        GameManager.RegisterSceneFader(this);
    }

    public void FadeOut()
    {
        anim.SetTrigger(faderId);
    }
}
