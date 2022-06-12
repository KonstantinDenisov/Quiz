using UnityEngine;

[CreateAssetMenu(fileName = "Olololo", menuName = "Configs/Step")]
public class StepSO : ScriptableObject
{
    #region Public Field

    [TextArea (4,8)]
    public string QuestionLabel;
    
    [TextArea (4,8)]
    public string Answer1;
    
    [TextArea (4,8)]
    public string Answer2;
    
    [TextArea (4,8)]
    public string Answer3;
    
    [TextArea (4,8)]
    public string Answer4;
    
    public int Check;
    
    public StepSO[] Choices;

    #endregion


}
