using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
    private SoundScape sounds1;
    private SoundScape sounds2;
    private GameObject playerXRRig;
    private List<AudioClip> randomSounds = new List<AudioClip>();
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public float fadeDuration = 1f;
    private float radius = 5f;
    private float fadeStart;
    private float probabilityOfRandomSound = 0.1f;

    private IEnumerator fadeCoroutine = null;

    //Singleton pattern
    //The static keyword is our clue here that we are 
    //creating a globally available variable 
    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // if this is the first Instance set our static variable to this one 
            DontDestroyOnLoad(Instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("First Audio Manager Made!");
        }
        else
        {
            Destroy(gameObject); // if our Instance variable has already been set destroy any new ones
            Debug.Log("Darn a Audio Manager beat me to it!");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerXRRig = GameObject.FindWithTag("Player");
        
        //Debug.Log(playerXRRig.name);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource1.loop = true;
        audioSource2.loop = true;
        audioSource1.spatialBlend = 0;
        audioSource2.spatialBlend = 0;
        fadeStart = 0;
    }

    private void Update()
    {
        if(randomSounds.Count > 0)
        {
            float rand = Random.value; // 0 - 1
            
            //probability
            if (rand < probabilityOfRandomSound)
            {
                PlayRandomSound();
            }
        }
    }

    private void PlayRandomSound()
    {
        int randomIndex = Random.Range(0,randomSounds.Count);//min inclusive, max exclusive
        float randomAngle = Random.Range(0, 360);
        float randomX = playerXRRig.transform.position.x + radius * Mathf.Cos(randomAngle);
        float randomZ = playerXRRig.transform.position.z + radius * Mathf.Sin(randomAngle);
 
        AudioSource.PlayClipAtPoint(randomSounds[randomIndex], new Vector3(randomX,0, randomZ));

    }

    public void Fade(SoundScape newSounds)
    {
    
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        if (audioSource1.isPlaying)
        {
            if(sounds1 == newSounds)
            {
                Debug.Log("These sounds already playing on Audio Source 1");
                Debug.Log(sounds1.name);
                return;
            }
            
            sounds2 = newSounds;
            probabilityOfRandomSound = sounds2.FrequencyOfRandomSounds;
            radius = sounds2.randomSoundDistance;
            audioSource2.clip = newSounds.AmbientLoop;
            audioSource2.volume = 0;
            randomSounds = sounds2.RandomShortSounds;
            audioSource2.Play();
            //fade in sounds 2 / audioSource 2 and fade out sounds 1 / audio source 1
            fadeCoroutine = FadeRoutine(audioSource2, audioSource1);
        }
        else
        {
            if (sounds2 == newSounds)
            {
                Debug.Log("These sounds already playing on Audio Source 2");
                Debug.Log(sounds2.name);
                return;
            }
            sounds1 = newSounds;
            probabilityOfRandomSound = sounds1.FrequencyOfRandomSounds;
            radius = sounds1.randomSoundDistance;
            audioSource1.clip = newSounds.AmbientLoop;
            audioSource1.volume = 0;
            randomSounds = sounds1.RandomShortSounds;
            audioSource1.Play();
            //fade in sounds 1 / audioSource 1 and fade out sounds 2 / audio source 2
            fadeCoroutine = FadeRoutine(audioSource1, audioSource2);
        }

      
        StartCoroutine(fadeCoroutine);
    }

    IEnumerator FadeRoutine(AudioSource FadeIn, AudioSource FadeOut)
    {
       
        float t = 0;
        while (t <= fadeDuration)
        {
            float val = Mathf.Lerp(0, 1, t / fadeDuration);
            FadeIn.volume = val; // fade in this one
            FadeOut.volume = 1 - val;//inverse or opposite of the fadeIn source
            t += Time.deltaTime;
            fadeStart = val;//keep track of where we are in the fade
            yield return null;
        }

        //just so it's exactly 1 & 0 at the end
        FadeIn.volume = 1;
        FadeOut.volume = 0;

        FadeOut.Stop();
    }


}
