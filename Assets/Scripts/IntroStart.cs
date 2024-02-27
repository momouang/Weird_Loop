using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStart : MonoBehaviour
{
    public enum FunctionType
    {
        Start,
        Quit,
    }
    public FadeScreen fadeScreen;

    public FunctionType functionType;

    bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
            return;

        if(other.CompareTag("Player"))
        {
            FindObjectOfType<Audio_Manager>().Play("Touch");
            hasTriggered = true;
            switch(functionType)
            {
                case FunctionType.Start:
                    GameStart();
                    break;

                case FunctionType.Quit:
                    GameQuit();
                    break;
            }
        }
    }

    void GameStart() => StartCoroutine(StartGame());


    void GameQuit()
    {
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene("Loop01");
        Destroy(gameObject);
    }
}
