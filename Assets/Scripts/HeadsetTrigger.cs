using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HeadsetTrigger : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public bool isTriggered = false;

    public static event Action OnAddTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Headset")
        {
            StartCoroutine(StartTransfer());
            isTriggered = true;
        }
    }

    IEnumerator StartTransfer()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        OnAddTime?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
