using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings 
{
    private const int OnVolumeSaveKey = 1;
    private const int OffVolumeSaveKey = 1;

    private const float MaxValue = 0;
    private const float MinValue = -80;

    public event Action<bool> VolumeChanged;

    private string _name;
    private bool _isOn;

    private AudioMixerGroup _audioMixer;
    private Button _button;
    
    public AudioSettings(string name, AudioMixerGroup audioMixer, string prefName, Button button)
    {
        bool isOn = GetIsOnSave(PlayerPrefs.GetInt(prefName, OnVolumeSaveKey));

        _audioMixer = audioMixer;
        _name = name;
        PrefName = prefName;
        
        _button = button;

        SetIsOn(isOn);

        _button.onClick.AddListener(SwitchIsOn);
    }

    public bool IsOn => _isOn;
    public string Name => _name;
    private string PrefName { get; }

    public void UnsubscribeEvents()
    {
        _button.onClick.RemoveListener(SwitchIsOn);
    }

    public void SwitchIsOn()
    {
        _isOn = !_isOn;
        SetIsOn(_isOn);
    }

    public void SetIsOn(bool isOn)
    {
        _isOn = isOn;

        if (isOn)
            TurnOnSound();
        else
            TurnOffSound();

        VolumeChanged?.Invoke(isOn);
        PlayerPrefs.SetInt(PrefName, GetIsOnSave(_isOn));
    }

    private void TurnOffSound()
    {
        Debug.Log("turn off " + _name);
        _audioMixer.audioMixer.SetFloat(PrefName, MinValue);
    }

    private void TurnOnSound()
    {
        _audioMixer.audioMixer.SetFloat(PrefName, MaxValue);
    }

    private bool GetIsOnSave(int value) => value == OnVolumeSaveKey;
    private int GetIsOnSave(bool value) => value ? 1 : 0;
}
