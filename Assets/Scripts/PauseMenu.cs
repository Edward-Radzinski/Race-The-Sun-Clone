using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _audioSource;

    private bool _activePausePanel = false;

    public void ActivePausePanel()
    {
        Time.timeScale = System.Convert.ToInt32(_activePausePanel);
        if (_activePausePanel) _audioSource.Play();
        else _audioSource.Pause();
        _activePausePanel = !_activePausePanel;
        _pausePanel.SetActive(_activePausePanel);
    }
}
