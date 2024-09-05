using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour
{
    [SerializeField] private SkillButton skillButton0;
    [SerializeField] private SkillButton skillButton1;
    [SerializeField] private SkillButton skillButton2;
    [SerializeField] private SkillButton skillButton3;
    [SerializeField] private SkillButton skillButton4;

    public SkillButton SkillButton0 => skillButton0;
    public SkillButton SkillButton1 => skillButton1;
    public SkillButton SkillButton2 => skillButton2;
    public SkillButton SkillButton3 => skillButton3;
    public SkillButton SkillButton4 => skillButton4;
}
