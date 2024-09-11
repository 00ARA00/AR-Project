using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsPanel : MonoBehaviour
{
    [SerializeField] private SkillButton[] skillButtons;


    public SkillButton[] SkillButtons => skillButtons;
}
