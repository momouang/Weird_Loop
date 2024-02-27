using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRCPTriggerZone : MonoBehaviour
{
    public string playerTag = "Player";
    //private bool playerInZone;

    public UnityEvent OnTriggerZoneEntered = new UnityEvent();
    public UnityEvent OnTriggerZoneExited = new UnityEvent();

    private void Update()
    {
       // if (playerInZone == true)
       // {
            //do some animation or something that requires update
       // }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (OnTriggerZoneEntered != null && CheckCollisionObject(other.gameObject))
        {
            //playerInZone = true;

            OnTriggerZoneEntered.Invoke(); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other);
        if (OnTriggerZoneExited != null && CheckCollisionObject(other.gameObject))
        {
          //  playerInZone = false;

            OnTriggerZoneExited.Invoke();
        }
    }

    private bool CheckCollisionObject(GameObject otherGameObject)
    {
        return otherGameObject.CompareTag(playerTag.Trim());
    }
}
