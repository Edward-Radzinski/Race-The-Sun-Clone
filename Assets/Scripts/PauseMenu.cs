using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _audioSource;

    static public bool _activePausePanel = false;

    public void ActivePausePanel()
    {
        _activePausePanel = !_activePausePanel;
        Time.timeScale = System.Convert.ToInt32(!_activePausePanel);
        if (!_activePausePanel && Options._audioOn) _audioSource.Play();
        else _audioSource.Pause();
        _pausePanel.SetActive(_activePausePanel);
    }
}
