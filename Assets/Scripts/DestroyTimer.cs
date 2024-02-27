using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private void Awake()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Timer");
        if (g)
            Destroy(g);
    }
}
