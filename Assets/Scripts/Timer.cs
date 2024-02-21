using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] TMP_Text timeText;
    [SerializeField] float remainingTime;

    public bool isFailed;



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
            remainingTime = 0;
            isFailed = true;
        }
    }

    void StartTimer()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeIncreases()
    {
        remainingTime += 30;
    }
}
