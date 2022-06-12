using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour
{
    #region Private Field

    [SerializeField] private Button _playAgain;
    [SerializeField] private TextMeshProUGUI _statisticLabel;
    

    #endregion


    #region Private Methods

    private void Start()
    {
        _playAgain.onClick.AddListener(PlayAgainOnCliced);
        SetStatisticLabel();
    }

    private void PlayAgainOnCliced()
    {
        SceneLoader.Instance.LoadScene(0);
    }

    private void SetStatisticLabel()
    {
        _statisticLabel.text = $"колличество шагов - {ScoreManager.Instance.StepValue} " +
            $"колличество правильных ответов - {ScoreManager.Instance.Points}" +
            $"количество неправильных ответов - {ScoreManager.Instance.WrongValue}";
    }

    #endregion
}
