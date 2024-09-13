using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsWidget : MonoBehaviour
{
    [SerializeField] private SpawnInitializer spawnInitializer;
    [SerializeField] private TextMeshProUGUI strengthUIText;
    [SerializeField] private TextMeshProUGUI dexterityUIText;
    [SerializeField] private TextMeshProUGUI intelligenceUIText;

    private PlayerLocalStats _heroLocalStats;

    private float _strength;
    private float _dexterity;
    private float _intelligence;

    private void Awake()
    {
        spawnInitializer.ImageTracker.OnImageTracked -= OnImageTracked;
        spawnInitializer.ImageTracker.OnImageTracked += OnImageTracked;
    }

    private void OnImageTracked()
    {
        _heroLocalStats = spawnInitializer.ImageTracker.HeroInitializer.Stats;

        ChangeWidgetAttributes();

        _heroLocalStats.OnAttributesChanged -= OnAttributesChanged;
        _heroLocalStats.OnAttributesChanged += OnAttributesChanged;
    }

    private void OnAttributesChanged()
    {
        ChangeWidgetAttributes();
    }

    private void ChangeWidgetAttributes()
    {
        (_strength, _dexterity, _intelligence) = _heroLocalStats.GetAttributes();

        strengthUIText.text = _strength.ToString();
        dexterityUIText.text = _dexterity.ToString();
        intelligenceUIText.text = _intelligence.ToString();
    }
}
