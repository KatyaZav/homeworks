using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UiAudioHandler : MonoBehaviour
{
    private const string SoundName = "SoundVolume";
    private const string MusicName = "MusicVolume";

    [SerializeField] private Button _musicButton, _soundButton;
    [SerializeField] private AudioMixerGroup _masterGroup;

    [SerializeField] private Text _soundText, _musicText;

    private AudioSettings _soundSettings, _musicSettings;
    private AudioButtonView _soundView, _musicView;

    void Start()
    {
        _soundSettings = new AudioSettings("звук", _masterGroup, SoundName, _soundButton);
        _musicSettings = new AudioSettings("музыка", _masterGroup, MusicName, _musicButton);

        _soundView = new AudioButtonView(_soundSettings, _soundText);
        _musicView = new AudioButtonView(_musicSettings, _musicText);

    }

    private void OnDestroy()
    {
        _soundSettings.UnsubscribeEvents();
        _musicSettings.UnsubscribeEvents();

        _soundView.UnsubscribeEvents();
        _musicView.UnsubscribeEvents();
    }
}
