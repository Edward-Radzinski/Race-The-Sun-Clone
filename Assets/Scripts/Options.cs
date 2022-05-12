using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private Text _audioBtn;
    [SerializeField] private Text _acceleratorBtn;
    [SerializeField] private Slider _sensitivitySlider, _volumeSlider;

    private bool _activeOptionsPanel = false;
    static public bool _audioOn = true;
    private float _sensitivity = 1, _volume = 1;
    private bool _accelerator = false;

    private void Start()
    {
        _audioOn = System.Convert.ToBoolean(PlayerPrefs.GetFloat("Audio"));   
        _accelerator = System.Convert.ToBoolean(PlayerPrefs.GetFloat("Accelerator"));

        Debug.Log(_sensitivity);
        if (PlayerPrefs.HasKey("Sensitivity")) _sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        Debug.Log(_sensitivity);
        if (PlayerPrefs.HasKey("Volume")) _volume = PlayerPrefs.GetFloat("Volume");
        if (_audioOn) _audioSource.Play();

        _sensitivitySlider.value = _sensitivity;
        _volumeSlider.value = _volume;

        ChangeLabel(_accelerator, _acceleratorBtn);
        ChangeLabel(_audioOn, _audioBtn);
    }

    private void ChangeLabel(bool smthBool, Text text)
    {
        if (smthBool) text.text = "ON";
        else text.text = "OFF";
    }

    public void ActiveOptionsPanel()
    {
        _activeOptionsPanel = !_activeOptionsPanel;
        _optionsPanel.SetActive(_activeOptionsPanel);
    }

    public void ChangeTypeOfControl()
    {
        _accelerator = !_accelerator;
        ChangeLabel(_accelerator, _acceleratorBtn);
        PlayerPrefs.SetFloat("Accelerator", System.Convert.ToInt32(_accelerator));
    }

    public void AudioState()
    {
        _audioOn = !_audioOn;
        if (_audioOn && !PauseMenu._activePausePanel) _audioSource.Play();
        else if(!_audioOn) _audioSource.Pause();
        ChangeLabel(_audioOn, _audioBtn);
        PlayerPrefs.SetFloat("Audio", System.Convert.ToInt32(_audioOn));
    }

    public void ChangeSensitivity(float newSensitivity)
    {
        _sensitivity = newSensitivity;
        PlayerPrefs.SetFloat("Sensitivity", _sensitivity);
    }

    public void ChangeVolume(float newVolume)
    {
        _volume = newVolume;
        _audioSource.volume = newVolume;
        PlayerPrefs.SetFloat("Volume", _volume);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }


}
