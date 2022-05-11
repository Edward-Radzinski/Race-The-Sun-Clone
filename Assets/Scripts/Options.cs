using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private Text _audioBtn;
    [SerializeField] private Text _acceleratorBtn;
    [SerializeField] private Slider _sensitivitySlider, _volumeSlider;

    private bool _activeOptionsPanel = false;
    private bool _audioOn = true;
    private float _sensitivity = 1, _volume = 1;
    private bool _accelerator = false;

    private void Start()
    {
        _sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        _volume = PlayerPrefs.GetFloat("Volume");
        _audioOn = System.Convert.ToBoolean(PlayerPrefs.GetFloat("Audio"));
        _accelerator = System.Convert.ToBoolean(PlayerPrefs.GetFloat("Accelerator"));

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
        PlayerPrefs.SetFloat("Volume", _volume);
    }

}
