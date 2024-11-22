using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtonView
{
    private const string Off = "выкл";
    private const string On = "вкл";

    private Text _buttonText;
    private AudioSettings _audioSettings;

    public AudioButtonView(AudioSettings settings, Text text)
    {
        _buttonText = text;
        _audioSettings = settings;

        OnChangeVolume(_audioSettings.IsOn);

        _audioSettings.VolumeChanged += OnChangeVolume;
    }

    public void UnsubscribeEvents()
    {
        _audioSettings.VolumeChanged -= OnChangeVolume;
    }

    public void OnChangeVolume(bool isOn)
    {
        _buttonText.text = _audioSettings.Name + " " + (isOn ? On : Off);
    }
}
