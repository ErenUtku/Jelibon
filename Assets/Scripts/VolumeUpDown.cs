using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeUpDown : MonoBehaviour
{
    public AudioMixer mixer;
   public void SetLevel(float slidervalue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(slidervalue) * 20 );
    }
}
