using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField] protected PlayerInitializer playerInitializer;

    [SerializeField] protected int index;
    [SerializeField] protected string skillName;
    [SerializeField] protected float strengthRequirment;
    [SerializeField] protected float dexterityRequirment;
    [SerializeField] protected float intelligenceRequirment;
    [SerializeField] protected Sprite skillIcon;

    private Color _disableColor;
    private Color _enableColor;
    private float _strengtAttribute;
    private float _dexterityAttribute;
    private float _intelligenceAttribute;
    private AnimationController _animationController;
    private SkillButton _skillButton;

    protected PlayerInitializer enemyInitializer;

    private bool _isAvaible = true;

    public bool IsAvaible => _isAvaible;

    private void Awake()
    {
        _disableColor = new Color(150, 150, 150);
        _enableColor = new Color(255, 255, 255);

        _animationController = playerInitializer.AnimationController;

        _strengtAttribute = playerInitializer.Stats.Strength;
        _dexterityAttribute = playerInitializer.Stats.Dexterity;
        _intelligenceAttribute = playerInitializer.Stats.Intelligence;

        playerInitializer.AnimationEventController.OnTriggerSkillEffect -= OnTriggerSkillEffect;
        playerInitializer.AnimationEventController.OnTriggerSkillEffect += OnTriggerSkillEffect;
        playerInitializer.OnInitializesConnection -= OnInitializesConnection;
        playerInitializer.OnInitializesConnection += OnInitializesConnection;

    }

    private void OnTriggerSkillEffect()
    {
        SkillEffect();
    }

    private void OnInitializesConnection()
    {
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _skillButton = playerInitializer.SpawnInitializer.UISystem.SkillsPanel.SkillButtons[index];

        InizializeButtonUI();
        Initialize();
        AttributesCheck();

        _skillButton.OnSkillButtonClick -= OnSkillButtonClick;
        _skillButton.OnSkillButtonClick += OnSkillButtonClick;
    }

    private void OnSkillButtonClick()
    {
        _animationController.SkillAnimation(skillName);
    }

    protected virtual void Initialize()
    {
        enemyInitializer = playerInitializer.SpawnInitializer.ImageTracker.EnemyInitializer;
    }

    protected abstract void SkillEffect();

    private void InizializeButtonUI()
    {
        _skillButton.StrengthUIText.text = strengthRequirment.ToString();
        _skillButton.DexterityUIText.text = dexterityRequirment.ToString();
        _skillButton.IntelligenceUIText.text = intelligenceRequirment.ToString();

        _skillButton.ChangeIcon(skillIcon);
    }

    private void AttributesCheck()
    {
        if (_strengtAttribute < strengthRequirment || _dexterityAttribute < dexterityRequirment || _intelligenceAttribute < intelligenceRequirment)
        {
            if (_isAvaible)
            {
                _skillButton.DisableSkill();
                _isAvaible = false;
            }
        }
        else
        {
            if (!_isAvaible)
            {
                _skillButton.EnableSkill();
                _isAvaible = true;
            }
        }
    }
}
