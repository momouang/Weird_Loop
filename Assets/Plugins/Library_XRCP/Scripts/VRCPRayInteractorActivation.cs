using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Deactivate Ray
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class VRCPRayInteractorActivation : MonoBehaviour
{

    private XRRayInteractor rayInteractor = null;
    private bool isSwitchedOn = true;
    public bool startOff = false;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        if (startOff)
        {
            SwitchOffRay();//start with it off
        }
    
    }

    private void Start()
    {

    }

    public void SwitchOnRay()
    {
        if (isSwitchedOn == false)
        {
            isSwitchedOn = true;
            rayInteractor.enabled = true;
        }
    }

    public void SwitchOffRay()
    {
        if (isSwitchedOn == true)
        {
            isSwitchedOn = false;
            rayInteractor.enabled = false;
        }
    }
}
