using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField] protected PlayerInitializer playerInitializer;

    [SerializeField] protected float strengthRequirment;
    [SerializeField] protected float dexterityRequirment;
    [SerializeField] protected float intelligenceRequirment;

    private float _strengtAttribute;
    private float _dexterityAttribute;
    private float _intelligenceAttribute;
    private SkillButton _skillButton;
    private ImageTracker _imageTracker;

    private bool _isAvaible;

    public bool IsAvaible => _isAvaible;

    private void Awake()
    {
        _strengtAttribute = playerInitializer.Stats.Strength;
        _dexterityAttribute = playerInitializer.Stats.Dexterity;
        _intelligenceAttribute = playerInitializer.Stats.Intelligence;

        playerInitializer.OnInitializesConnection -= OnInitializesConnection;
        playerInitializer.OnInitializesConnection += OnInitializesConnection;

    }

    private void OnInitializesConnection()
    {
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        playerInitializer.SpawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _skillButton = playerInitializer.SpawnInitializer.SkillsPanel.SkillButton0;

        _skillButton.StrengthUIText.text = strengthRequirment.ToString();
        _skillButton.DexterityUIText.text = dexterityRequirment.ToString();
        _skillButton.IntelligenceUIText.text = intelligenceRequirment.ToString();
    }

    protected virtual void AttributesCheck()
    {
        if (_strengtAttribute < strengthRequirment || _dexterityAttribute < dexterityRequirment || _intelligenceAttribute < intelligenceRequirment)
        {
            _isAvaible = false;
        }
        else
        {
            _isAvaible = true;
        }
        Debug.Log(_isAvaible);
    }
}
