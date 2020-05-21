using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    //Will add functionality to change to fullscreen mode on this script in addition to volume. 
    //Renaming the script file would break the file so I will keep it named 'volume.'
    public AudioMixer audioMixer;

    public void SetVolume (float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }
  
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("The game has been set to fullscreen!!!!");
    }
    
}
