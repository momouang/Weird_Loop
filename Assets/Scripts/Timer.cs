using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public FadeScreen fadeScreen;

    [SerializeField] TMP_Text timeText;
    [SerializeField] float remainingTime;
    [SerializeField] AudioSource audioSource;
    public bool isFailed;

    public int beepFrom = 5;
    public int currentBeep = 5;

    bool hasTimedUp = false;


    private void OnEnable()
    {
        HeadsetTrigger.OnAddTime += TimeIncreases;
    }

    private void OnDisable()
    {
        HeadsetTrigger.OnAddTime -= TimeIncreases;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        StartTimer();

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            if (hasTimedUp)
                return;

            hasTimedUp = true;
            StartCoroutine(TimeUp());
            remainingTime = 0;
            isFailed = true;
        }

        if((int)remainingTime == currentBeep)
        {
            currentBeep -= 1;
            Debug.Log("Test");
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    void StartTimer()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator TimeUp()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene("Intro");
    }

    void TimeIncreases()
    {
        remainingTime += 20;
        currentBeep = beepFrom;
    }
}
