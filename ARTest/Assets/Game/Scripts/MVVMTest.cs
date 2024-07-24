using MVVM.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVVMTest : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool makeDamage;
    [Space]
    [SerializeField] private float maxHealthNewValue;
    [SerializeField] private bool setValueToMax;
    [Space]
    [SerializeField] private int goldAddValue;
    [SerializeField] private bool goldAdd;

    private GameVM _gameVM;
    private GameModel.ParameterHealth _health;
    private GameModel.ParameterMaxHealth _maxHealth;
    private GameModel.ParameterGold _gold;

    private void Awake()
    {
        _gameVM = GameVM.Instance;
        _health = _gameVM.Data<GameModel.ParameterHealth>();
        _maxHealth = _gameVM.Data<GameModel.ParameterMaxHealth>();
        _gold = _gameVM.Data<GameModel.ParameterGold>();
    }

    private void Start()
    {
        _health.AddListener(OnHealthChanged);
        _maxHealth.AddListener(OnMaxHealthChanged);
        _gold.AddListener(OnGoldChanged);

        _maxHealth.AddModificator(this, 20);
        _maxHealth.AddPercentageModificator(this, 150);

        OnGoldChanged(0);
    }

    private void OnDestroy()
    {
        _health.RemoveListener(OnHealthChanged);
        _maxHealth.RemoveListener(OnMaxHealthChanged);
        _gold.RemoveListener(OnGoldChanged);
    }

    private void OnMaxHealthChanged()
    {
        Debug.Log(string.Format("Max Health was changed. Now it is {0}", _maxHealth.Value));
    }

    private void OnHealthChanged()
    {
        Debug.Log(string.Format("Health was changed. Now it is {0}/{1}", _health.Value, _maxHealth.Value));
    }

    private void OnGoldChanged(int obj)
    {
        Debug.Log(string.Format("Gold was changed. Now it is {0}", _gold.Value));
    }

    // Test //

    private void Update()
    {
        if (setValueToMax)
        {
            setValueToMax = false;
            _maxHealth.SetValue(maxHealthNewValue);
        }


        if (makeDamage)
        {
            makeDamage = false;
            if (!_health.TryMakeDamage(damage))
            {
                Debug.Log("Its dead!");
            }
        }


        if (goldAdd)
        {
            goldAdd = false;
            _gold.Set(goldAddValue);
        }
    }
}
