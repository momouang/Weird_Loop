using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HeadsetTrigger : MonoBehaviour
{
    public ObjectCollectingManager objectManager;

    public FadeScreen fadeScreen;
    public bool isTriggered = false;

    public static event Action OnAddTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Headset")
        {
            if(objectManager.isCollected)
            {
                FindObjectOfType<Audio_Manager>().Play("Correct");
                StartCoroutine(StartTransfer());
                isTriggered = true;
            }
            else
            {
                FindObjectOfType<Audio_Manager>().Play("Error");
            }
        }
        if(other.tag == "Fake")
        {
            FindObjectOfType<Audio_Manager>().Play("Error");
        }
    }

    IEnumerator StartTransfer()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        OnAddTime?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator RestartTransfer()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
