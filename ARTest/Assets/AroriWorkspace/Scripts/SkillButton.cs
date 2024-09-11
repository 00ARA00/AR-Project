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

    public void DisableSkill()
    {
        buttonSkill.gameObject.SetActive(false);
        Color newColor = skillIcon.color;
        newColor = new Color(newColor.r * 0.5f, newColor.g * 0.5f, newColor.b * 0.5f, newColor.a);
        skillIcon.color = newColor;
    }

    public void EnableSkill()
    {
        buttonSkill.gameObject.SetActive(true);
        Color newColor = skillIcon.color;
        newColor = new Color(newColor.r * 2f, newColor.g * 2f, newColor.b * 2f, newColor.a);
        skillIcon.color = newColor;
    }
}
