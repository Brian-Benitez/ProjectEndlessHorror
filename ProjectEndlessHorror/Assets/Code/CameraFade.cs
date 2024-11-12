using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public Animator FadeInOutAnimator;

    private void Start()
    {
        FadeOffOfBlack();
    }
    public void FadeOffOfBlack()
    {
        FadeInOutAnimator.SetBool("IsFadeToBlack", false);
        FadeInOutAnimator.SetBool("IsFadeOut", true);
        Debug.Log("fade off of black");
    }

    public void FadeToBlack()
    {
        FadeInOutAnimator.SetBool("IsFadeToBlack", true);
        FadeInOutAnimator.SetBool("IsFadeOut", false);
        Debug.Log("fade to black");
    }
}
