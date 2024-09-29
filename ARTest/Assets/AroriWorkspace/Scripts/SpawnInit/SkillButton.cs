using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private Button buttonSkill;
    [SerializeField] private Image skillIcon;
    [SerializeField] private TextMeshProUGUI strengthUIText;
    [SerializeField] private TextMeshProUGUI dexterityUIText;
    [SerializeField] private TextMeshProUGUI intelligenceUIText;

    public event Action OnSkillButtonClick;
    public Button ButtonSkill => buttonSkill;
    public Image SkillIcon => skillIcon;
    public TextMeshProUGUI StrengthUIText => strengthUIText;
    public TextMeshProUGUI DexterityUIText => dexterityUIText;
    public TextMeshProUGUI IntelligenceUIText => intelligenceUIText;

    private void Awake()
    {
        buttonSkill.onClick?.AddListener(() => OnSkillButtonClick?.Invoke());
    }

    public void ChangeIcon(Sprite skillIcon)
    {
        this.skillIcon.sprite = skillIcon;
    }

    public void DisableSkillButton()
    {
        buttonSkill.interactable = false;
    }

    public void EnableSkillButton()
    {
        buttonSkill.interactable = true;
    }
}
