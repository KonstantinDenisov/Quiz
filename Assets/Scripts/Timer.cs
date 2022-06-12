using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Private Fields

    private Action _completeCallback;
    private bool _isStarted;
    private float _time;

    #endregion

    #region Public Methods

    public void StartTimer(float time, Action completeCallback)
    {
        _completeCallback = completeCallback;
        _isStarted = true;
        _time = time;
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        if (!_isStarted)
            return;
        
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            _isStarted = false;
            _completeCallback.Invoke();
        }
    }

    #endregion
    
}
