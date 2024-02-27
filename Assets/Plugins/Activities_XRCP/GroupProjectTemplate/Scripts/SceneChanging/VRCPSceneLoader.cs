using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VRCPSceneLoader : MonoBehaviour
{
    public VRCPFadeScreen fadeScreen;

    // When scene is loaded and play begins
    public UnityEvent OnLoad = new UnityEvent();

    //binding to the sceneLoaded event and invoking our public event to use
    //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    private void Awake()
    {
        SceneManager.sceneLoaded += PlayEvent;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= PlayEvent;
    }

    private void PlayEvent(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
    }

    //This is the simple way to go to the next scene, but if you have a very complex
    //scene things might stutter as you transition because it loads everything at once
    public void GoToScene(string sceneName)
    {
        StartCoroutine(GoToSceneRoutine(sceneName));
    }

    //https://docs.unity3d.com/Manual/Coroutines.html
    //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
    IEnumerator GoToSceneRoutine(string sceneName)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneName);
    }

    //Async means asynchronously which means that things get loaded in the background
    //And only once everything is ready to use do we actually switch scenes
    public void GoToSceneAsync(string sceneName)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneName));
    }

    //https://docs.unity3d.com/Manual/Coroutines.html
    //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
    IEnumerator GoToSceneAsyncRoutine(string sceneName)
    {
        fadeScreen.FadeOut();

        //https://docs.unity3d.com/ScriptReference/AsyncOperation.html
        //Launch the new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float timer = 0;
        while (timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }

}
