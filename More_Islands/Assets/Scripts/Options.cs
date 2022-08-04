using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]private AudioMixerGroup _mixer;
    [SerializeField]private Slider _masterSlider;
    [SerializeField]private Slider _musicSlider;
    [SerializeField]private Slider _embientSlider;
    [SerializeField]private Slider _effectsSlider;
    void Start()
    {
        loadOptions();
    }

    public void MusicTogle(bool enable)
    {
        if(enable) _mixer.audioMixer.SetFloat("MusicVolume",0);
        else  _mixer.audioMixer.SetFloat("MusicVolume",-80);
       
    }

    private void Update() {
        MasterVolumeChange();
        MusicVolumeChange();
        EmbientVolumeChange();
        EffectsVolumeChange();
    }

    public void MasterVolumeChange()
    {
        _mixer.audioMixer.SetFloat("MasterVolume",  _masterSlider.value);
    }

    public void MusicVolumeChange()
    {
        _mixer.audioMixer.SetFloat("MusicVolume",  _musicSlider.value);
    }

    public void EmbientVolumeChange()
    {
        _mixer.audioMixer.SetFloat("EmbientVolume",  _embientSlider.value);
    }

    public void EffectsVolumeChange()
    {
        _mixer.audioMixer.SetFloat("EffectsVolume",  _effectsSlider.value);
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("MasterValue",_masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
        PlayerPrefs.SetFloat("EmbientVolume", _embientSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", _effectsSlider.value);

        loadOptions();
    }

    private void loadOptions(){
        if(PlayerPrefs.HasKey("MasterValue"))
        {
            _masterSlider.value = PlayerPrefs.GetFloat("MasterValue");
            _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
            _embientSlider.value = PlayerPrefs.GetFloat("EmbientVolume");
            _effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        }

    }
}
