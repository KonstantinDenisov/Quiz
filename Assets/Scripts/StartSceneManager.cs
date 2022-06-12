using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    #region Private Field

    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;
   

    #endregion

    #region Private Methods
    private void Start()
    {
        _start.onClick.AddListener(StartOnClicked);
        _exit.onClick.AddListener(ExitOnClicked);
       
    }

    private void ExitOnClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void StartOnClicked()
    {
        SceneLoader.Instance.LoadScene(1);
    }
    #endregion
}
