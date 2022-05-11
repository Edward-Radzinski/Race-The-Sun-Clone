using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _activePausePanel = false;

    public void ActivePausePanel()
    {
        Time.timeScale = System.Convert.ToInt32(_activePausePanel);
        _activePausePanel = !_activePausePanel;
        _pausePanel.SetActive(_activePausePanel);
    }
}
