using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class A7SimpleMicSource : MonoBehaviour
{
    AudioSource _audioSource;

    //Microphone Input
    public AudioClip _audioClip;
    public bool _getDeviceNames;
    public string _selectedDevice;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(_getDeviceNames)
        {
            Debug.Log("Devices you have available.");
            foreach (var device in Microphone.devices)
            {
                Debug.Log("Name: " + device);
            }
        }

        if (Microphone.devices.Length > 0)
        {
            if (_selectedDevice == "")
            {
                _selectedDevice = Microphone.devices[0].ToString();
            }
            _audioSource.clip = Microphone.Start(_selectedDevice, true, 12, AudioSettings.outputSampleRate);
        }
        else
        {
            _audioSource.clip = _audioClip;
        }
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
