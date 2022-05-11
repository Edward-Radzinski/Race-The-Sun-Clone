using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour
{
    private bool _left, _right;
    public void Left(bool turn)
    {
        _left = turn;
        Ship.Instance.hMove = turn && !_right ? -1 : 0;
        if (!turn && _right) Right(true);
    }
    public void Right(bool turn)
    {
        _right = turn;
        Ship.Instance.hMove = turn && !_left ? 1 : 0;
        if (!turn && _left) Left(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

}
