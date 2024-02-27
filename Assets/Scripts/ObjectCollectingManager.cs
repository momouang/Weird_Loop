using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectingManager : MonoBehaviour
{
    public bool isCollected;
    public GameObject CubieParticle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(CubieParticle, transform.position, transform.rotation);
            FindObjectOfType<Audio_Manager>().Play("Pick Up");
            Destroy(gameObject);
            isCollected = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(CubieParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            isCollected = true;
        }
    }
}
