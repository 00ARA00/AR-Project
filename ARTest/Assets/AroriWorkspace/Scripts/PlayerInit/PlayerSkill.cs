using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField] protected PlayerInitializer playerInitializer;

    [SerializeField] private int index;
    [SerializeField] private float strengthRequirment;
    [SerializeField] private float dexterityRequirment;
    [SerializeField] private float intelligenceRequirment;
    [SerializeField] private Sprite skillIcon;
    [SerializeField] private bool isEnemySkill;
    [SerializeField] private string animationName;
    [SerializeField] private float animationDelayModificator;

    private float _strengtAttribute;
    private float _dexterityAttribute;
    private float _intelligenceAttribute;
    private float _animationDelay;
    private bool _isAvaible = true;

    private AnimationController _animationController;
    private UISystem _uISystem;
    private SkillButton _skillButton;

    protected PlayerInitializer enemyInitializer;

    private PlayerLocalStats _playerLocalStats;

    private float _totalCost;

    public bool IsAvaible => _isAvaible;
    public bool IsEnemySkill => isEnemySkill;
    public float AnimationDelay => _animationDelay;
    public string AnimationName => animationName;
    public float TotalCost => _totalCost;

    private void Awake()
    {
        _totalCost = strengthRequirment + dexterityRequirment + intelligenceRequirment;

        _playerLocalStats = playerInitializer.Stats;
        _animationController = playerInitializer.AnimationController;

        SyncAttributes();

        playerInitializer.OnInitializesConnection -= OnInitializesConnection;
        playerInitializer.OnInitializesConnection += OnInitializesConnection;

        playerInitializer.AnimationEventController.OnTriggerSkillEffect -= OnTriggerSkillEffect;
        playerInitializer.AnimationEventController.OnTriggerSkillEffect += OnTriggerSkillEffect;

        _playerLocalStats.OnAttributesChanged -= OnAttributesChanged;
        _playerLocalStats.OnAttributesChanged += OnAttributesChanged;
    }

    private void OnAttributesChanged()
    {
        SyncAttributes();
        AttributesCheck();
    }

    private void SyncAttributes()
    {
        (_strengtAttribute, _dexterityAttribute, _intelligenceAttribute) = _playerLocalStats.GetAttributes();
    }

    private void OnInitializesConnection()
    {
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _animationDelay = _animationController.GetAnimationLength(animationName, animationDelayModificator);

        if (!isEnemySkill)
        {
            InizializeButtonUI();

            _animationController.OnHeroReadyToUseSkill -= OnHeroReadyToUseSkill;
            _animationController.OnHeroReadyToUseSkill += OnHeroReadyToUseSkill;
        }

        InitializeEnemy();
        AttributesCheck();
    }

    private void OnHeroReadyToUseSkill()
    {
        AttributesCheck();
    }

    private void InizializeButtonUI()
    {
        _uISystem = playerInitializer.SpawnInitializer.UISystem;

        _skillButton = playerInitializer.SpawnInitializer.UISystem.SkillsPanel.SkillButtons[index];

        _skillButton.StrengthUIText.text = strengthRequirment.ToString();
        _skillButton.DexterityUIText.text = dexterityRequirment.ToString();
        _skillButton.IntelligenceUIText.text = intelligenceRequirment.ToString();

        _skillButton.ChangeIcon(skillIcon);

        _skillButton.OnSkillButtonClick -= OnSkillButtonClick;
        _skillButton.OnSkillButtonClick += OnSkillButtonClick;
    }

    protected virtual void InitializeEnemy()
    {
        if (!isEnemySkill) { enemyInitializer = playerInitializer.SpawnInitializer.EnemyInitializer; }
        if (isEnemySkill) { enemyInitializer = playerInitializer.SpawnInitializer.HeroInitializer; }
    }

    public void ActivateSkill()
    {
        _playerLocalStats.SetAttributes(_strengtAttribute - strengthRequirment, _dexterityAttribute - dexterityRequirment, _intelligenceAttribute - intelligenceRequirment);
        if (!isEnemySkill) { _uISystem.DisableAllSkillButtons(); }

        _animationController.SkillAnimation(this);
    }

    private void OnSkillButtonClick()
    {
        ActivateSkill();
    }

    private void OnTriggerSkillEffect(string skillName)
    {
        if (animationName == skillName)
            SkillEffect();
    }

    protected abstract void SkillEffect();

    private void AttributesCheck()
    {
        if (_strengtAttribute < strengthRequirment || _dexterityAttribute < dexterityRequirment || _intelligenceAttribute < intelligenceRequirment)
        {
            if (!isEnemySkill) { _skillButton.DisableSkillButton(); }
            _isAvaible = false;
        }
        else
        {
            if (!isEnemySkill) { _skillButton.EnableSkillButton(); }
            _isAvaible = true;
        }
    }
}
