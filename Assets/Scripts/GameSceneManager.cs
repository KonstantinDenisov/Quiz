using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameSceneManager : MonoBehaviour
{
    #region Private Field

    [SerializeField] private TextMeshProUGUI _questionLabel;
    [SerializeField] private TextMeshProUGUI _statisticsLabel;
    [SerializeField] private TextMeshProUGUI _buttonLabelAnswer1;
    [SerializeField] private TextMeshProUGUI _buttonLabelAnswer2;
    [SerializeField] private TextMeshProUGUI _buttonLabelAnswer3;
    [SerializeField] private TextMeshProUGUI _buttonLabelAnswer4;
    [SerializeField] private Button _buttonAnswer1;
    [SerializeField] private Button _buttonAnswer2;
    [SerializeField] private Button _buttonAnswer3;
    [SerializeField] private Button _buttonAnswer4;
    [SerializeField] private Button _buttonHint;
    [SerializeField] private StepSO _startStep;
    private StepSO _currentStep;
    private int _stepValue = 0;
    private int _hitPoints = 3;
    private int _points = 0;
    private int _wrongValue = 0;
    private Timer _timer;

    #endregion

    #region Private Methods
    private void Start()
    {
        SetStatisticsLabel();
        SetCurrentStep(_startStep);
        _buttonAnswer1.onClick.AddListener(ButtonAnswer1OnClicked);
        _buttonAnswer2.onClick.AddListener(ButtonAnswer2OnClicked);
        _buttonAnswer3.onClick.AddListener(ButtonAnswer3OnClicked);
        _buttonAnswer4.onClick.AddListener(ButtonAnswer4OnClicked);
        _buttonHint.onClick.AddListener(ButtonHintOnClicked);
    }

    private void ButtonHintOnClicked()
    {
        _buttonAnswer2.gameObject.SetActive(false);
        _buttonAnswer4.gameObject.SetActive(false);
    }
    

    private void ButtonAnswer4OnClicked()
    {
        CheckAnswer4();
        _stepValue++;
        SetStatisticsLabel();
        StatisticExport();
        // _timer.StartTimer(1, SetNextStep);
        SetNextStep();
        CheckGameOver();
    }

    private void ButtonAnswer3OnClicked()
    {
        CheckAnswer3();
        _stepValue++;
        SetStatisticsLabel();
        StatisticExport();
        // _timer.StartTimer(1, SetNextStep);
        SetNextStep();
        CheckGameOver();
    }

    private void ButtonAnswer2OnClicked()
    {
        CheckAnswer2();
        _stepValue++;
        SetStatisticsLabel();
        StatisticExport();
        // _timer.StartTimer(1, SetNextStep);
        SetNextStep();
        CheckGameOver();
    }

    private void ButtonAnswer1OnClicked()
    {
        CheckAnswer1();
        _stepValue++;
        SetStatisticsLabel();
        StatisticExport();
        // _timer.StartTimer(1, SetNextStep);
        SetNextStep();
        CheckGameOver();
    }

    private void SetCurrentStep(StepSO step)
    {
        if (step == null)
            return;
        _currentStep = step;

        _questionLabel.text = step.QuestionLabel;
        _buttonLabelAnswer1.text = step.Answer1;
        _buttonLabelAnswer2.text = step.Answer2;
        _buttonLabelAnswer3.text = step.Answer3;
        _buttonLabelAnswer4.text = step.Answer4;
    }

    private void SetNextStep()
    {
        Random r = new Random();
        StepSO nextStep = _currentStep.Choices[r.Next(0,31)];
        SetCurrentStep(nextStep);
    }
    private void CheckGameOver()
    {
        if (_hitPoints == 0)
            SceneLoader.Instance.LoadScene(2);
    }

    private void SetStatisticsLabel()
    {
        _statisticsLabel.text = $"количество шагов {_stepValue}, колличество оставшихся попыток - {_hitPoints}," +
            $" правельный ответов - {_points}, неправильных ответов - {_wrongValue}";
    }

    private void CheckAnswer1()
    {
        if (_currentStep.Check == 1)
            _points++;
        else
        {
            _wrongValue++;
            _hitPoints--;
        }

    }
    private void CheckAnswer2()
    {
        if (_currentStep.Check == 2)
            _points++;
        else
        {
            _wrongValue++;
            _hitPoints--;
        }

    }
    private void CheckAnswer3()
    {
        if (_currentStep.Check == 3)
            _points++;
        else
        {
            _wrongValue++;
            _hitPoints--;
        }

    }
    private void CheckAnswer4()
    {
        if (_currentStep.Check == 4)
            _points++;
        else
        {
            _wrongValue++;
            _hitPoints--;
        }

    }

    private void StatisticExport()
    {
        ScoreManager.Instance.WrongValue = _wrongValue;
        ScoreManager.Instance.Points = _points;
        ScoreManager.Instance.StepValue = _stepValue;
    }

    #endregion


}
