using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundScape : MonoBehaviour
{

    [Tooltip("Create a sound scape asset and assign it here")]
    public SoundScape zoneSounds = null;

    private void Awake()
    {

    }

    public void ChangeSound(){
        
        if(zoneSounds != null)
        {
            AudioManager.Instance.Fade(zoneSounds);
        }

    }

}
