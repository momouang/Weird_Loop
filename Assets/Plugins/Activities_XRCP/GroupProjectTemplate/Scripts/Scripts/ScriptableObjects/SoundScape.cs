using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Soundscape", menuName = "VRCP/Soundscape")]
public class SoundScape : ScriptableObject
{
    new public string name = "New Soundscape";
    public AudioClip AmbientLoop = null; 
    [Range(0, 0.5f)]
    public float FrequencyOfRandomSounds = 0.1f;
    public float randomSoundDistance = 1.0f;
    public List<AudioClip> RandomShortSounds = new List<AudioClip>();
}
