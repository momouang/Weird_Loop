using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRCPFadeAudioSource : MonoBehaviour
{
    //Our variables we will set in the editor
    public AudioSource audioSource;
    public float fadeDuration = 1f;
    //internal variables 
    private float fadeInStart = 0f;
    private float fadeOutStart = 1f;
    //We will use this to keep track of whether a coroutine is running
    private IEnumerator fadeCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        //We are using fadeCoroutine to correctly stop, store and start coroutines
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        //Set coroutine to our FadeIn coroutine
        fadeCoroutine = FadeIn(fadeDuration);
        StartCoroutine(fadeCoroutine);
    }

    public void Deactivate()
    {
        //We are using fadeCoroutine to correctly stop, store and start coroutines
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        //Set coroutine to our FadeIn coroutine
        fadeCoroutine = FadeOut(fadeDuration);
        StartCoroutine(fadeCoroutine);
    }

    IEnumerator FadeIn(float duration)
    {
        //Start playing our audio source
        audioSource.Play();
        float t = 0;
        while (t < 1)
        {
            t += Time.smoothDeltaTime / duration;
            float val = Mathf.Clamp(Mathf.Lerp(fadeInStart, 1f, t), 0f, 1f);
            // Keep track of where we have gotten to in the transition in case the user stops mid way
            fadeOutStart = val;
            //Set our audio volume
            audioSource.volume = val;

            yield return null;
        }

    }
    IEnumerator FadeOut(float duration)
    {

        float t = 0;
        while (t < 1)
        {
            t += Time.smoothDeltaTime / duration;
            float val = Mathf.Clamp(Mathf.Lerp(fadeOutStart, 0f, t), 0f, 1f);
            //keep track of where we got to in case the user starts the fade in before we are finished
            fadeInStart = val;
            //change our volume
            audioSource.volume = val;
            yield return null;
        }
        //Stop playing only after the while loop has finished
        audioSource.Stop();
    }
}
