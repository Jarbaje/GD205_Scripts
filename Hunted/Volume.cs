
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    //Controls the volume for the main audio of the game.
    public AudioMixer audioMixer;

    public void SetVolume (float volume) 
    {
        audioMixer.SetFloat("Volume", volume);
    }    
}