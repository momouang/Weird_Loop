using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCPFadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        if (fadeOnStart)
        {
            FadeIn();
        }

    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }


    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn,alphaOut, timer / fadeDuration); //interpolates between aIn & aOut by third parameter

            rend.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        //make sure at the end of the while loop that alpha is exactly equal to alphaOut
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut; 

        rend.material.SetColor("_BaseColor", newColor2);
    }
}
