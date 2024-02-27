using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// we are going to think abstractly about this
// as many of you won't be making a game
// what would be the states of your experience?
public enum State
{
    Beginning,
    Middle,
    End
}

public class GameManager : MonoBehaviour
{

    //Singleton pattern
    //The static keyword is our clue here that we are 
    //creating a globally available variable 
    public static GameManager Instance { get; private set; }

    public State experienceState;

    private VRCPSceneLoader sceneLoader;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // if this is the first Instance set our static variable to this one 
            DontDestroyOnLoad(Instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("First Game Manager Made!");
        }
        else
        {
            Destroy(gameObject); // if our Instance variable has already been set destroy any new ones
            Debug.Log("Darn a Game Manager beat me to it!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        VRCPSceneLoader[] loaders = GameObject.FindObjectsOfType<VRCPSceneLoader>();

        if (loaders.Length == 1)
        {
            sceneLoader = loaders[0];
        }
        else
        {
            Debug.Log("Error: you have " + loaders.Length + " scene loaders in the scene, you should have 1");
        }

    }

    public void UpdateState(State newState)
    {
        experienceState = newState;

        switch (experienceState)
        {
            case State.Beginning:
                HandleBeginning();
                break;
            case State.Middle:
                HandleMiddle();
                break;
            case State.End:
                //do something else
                HandleEnd();
                break;
        }

    }

    //Welcome moment
    private void HandleBeginning()
    {
        //Maybe there's something specific you need to do in code here.
        sceneLoader.GoToSceneAsync("0_StoryExampleScene");
    }

    private void HandleMiddle()
    {
        //Maybe there's something specific you need to do in code here.
        sceneLoader.GoToSceneAsync("1_StoryExampleScene");
    }

    private void HandleEnd()
    {
        //Maybe there's something specific you need to do in code here.
        sceneLoader.GoToSceneAsync("ExampleTeamMateScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
