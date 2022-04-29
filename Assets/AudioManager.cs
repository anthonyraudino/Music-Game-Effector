using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public float mixVol;
    public float mixHi;
    public float mixLow;
    public float mixFx;

    public AudioMixer mainMaster;
    public AudioSource musicSource;
    public bool isCurrentlyPlaying = false;
    public bool isCurrentlyPaused = false;

    private const string FXVol = "FXVol";
    private const string LoPassVol = "LoPassVol";
    private const string HiPassVol = "HiPassVol";
    private const string MixerVol = "MixerVol";

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        isCurrentlyPlaying = true;
        isCurrentlyPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolumeControl(float vol)
    {
        vol = Mathf.Log(vol) * 20;
        mainMaster.SetFloat(MixerVol, vol);
    }

    public void HiPassControl(float vol)
    {
        //  vol = Mathf.Log(vol) * 20;
        mainMaster.SetFloat(HiPassVol, vol);
    }

    public void LoPassControl(float vol)
    {
        //  vol = Mathf.Log(vol) * 20;
        mainMaster.SetFloat(LoPassVol, vol);
    }
    public void FXControl(float vol)
    {
        vol = Mathf.Log(vol) * 220;
        mainMaster.SetFloat(FXVol, vol);
    }


    public void PlayMusic()
    {
        if (!isCurrentlyPlaying)
        {
            musicSource.Play();
        }

        if (isCurrentlyPaused)
        {
            musicSource.Play();
            isCurrentlyPaused = false;
        }
    }

    public void RestartMusic()
    {
        musicSource.Stop();
        musicSource.Play();
        isCurrentlyPaused = false;
    }

    public void PauseMusic ()
    {
        musicSource.Pause();
        isCurrentlyPaused = true;

    }
}
