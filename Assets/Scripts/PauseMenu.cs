using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _audioSource;

    private bool _activePausePanel;

    private void Start()
    {
        _activePausePanel = false;
        PlayerPrefs.SetFloat("Pause", System.Convert.ToInt32(_activePausePanel));
        Time.timeScale = 1;
    }

    public void ActivePausePanel()
    { 
        Time.timeScale = System.Convert.ToInt32(_activePausePanel);
        _activePausePanel = !_activePausePanel;
        PlayerPrefs.SetFloat("Pause", System.Convert.ToInt32(_activePausePanel));
        if (!_activePausePanel && System.Convert.ToBoolean(PlayerPrefs.GetFloat("Audio"))) _audioSource.Play();
        else _audioSource.Pause();
        _pausePanel.SetActive(_activePausePanel);
    }
}
