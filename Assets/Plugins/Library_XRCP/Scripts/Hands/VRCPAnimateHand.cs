using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VRCPAnimateHand : MonoBehaviour
{
    Animator animator;
    private float gripTarget;
    private float gripCurrent;
    private float triggerTarget;
    private float triggerCurrent;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    public void SetGripTarget(float value)
    {
        gripTarget = value;
    }

    public void SetTriggerTarget(float value)
    {
        triggerTarget = value;
    }

    void AnimateHand()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.Lerp(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat("Grip", gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.Lerp(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat("Trigger", triggerCurrent);
        }
    }

}
