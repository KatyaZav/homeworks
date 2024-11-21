using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        _controller.Stoped += OnStoped;
    }

    private void OnDisable()
    {
        _controller.Stoped -= OnStoped;        
    }

    private void OnStoped(bool isStopped)
    {
        if (isStopped)
            _audioSource.Stop();
        else
            _audioSource.Play();
    }
}
