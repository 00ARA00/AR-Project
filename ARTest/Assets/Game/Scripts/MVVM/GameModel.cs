using MVVM.Core;
using MVVM.Data;
using MVVM.Example.Data;
using MVVM.Game.Data;
using System;


namespace MVVM.Game
{
    public class GameModel : MVVMModel
    {
        protected override void InitializeDatas()
        {
            var parameterDefault = new ParameterDefault();
            var parameterSave = new ParameterSave();

            DataMap.Add(typeof(ParameterDefault), parameterDefault);
            DataMap.Add(typeof(ParameterSave), parameterSave);



            var parameterMaxHealth = new ParameterMaxHealth();
            var parameterHealth = new ParameterHealth(parameterMaxHealth);
            var parameterGold = new ParameterGold();
            
            DataMap.Add(typeof(ParameterMaxHealth), parameterMaxHealth);
            DataMap.Add(typeof(ParameterHealth), parameterHealth);
            DataMap.Add(typeof(ParameterGold), parameterGold);
        }


        #region Default

        public class ParameterDefault : Core.DataDefaultValueFloat<ParameterDefault>
        {
            public override float DefaultValue => GameDefaultDataExample.CONSTANT_VALUE;
            protected override float Min => 0;
            protected override float Max => 100f;

            public ParameterDefault() { }

            public void SetValue(float value) => Value = value;
        }

        public class ParameterMaxHealth : Core.DataDefaultValueMod<ParameterMaxHealth>
        {
            public override float DefaultValue => GameDefaultData.MAX_HEALTH;
            protected override float Min => 0f;
            protected override float Max => 1000f;

            public ParameterMaxHealth() { }

            public void SetValue(float value) => Value = value;
        }

        public class ParameterHealth : Core.DataDefaultValueFloat<ParameterHealth>
        {
            public override float DefaultValue => GameDefaultData.MAX_HEALTH;
            protected override float Min => 0f;
            protected override float Max => _maxHealth.Value;

            private ParameterMaxHealth _maxHealth;
            private float _lastMaxHealth;

            public ParameterHealth(ParameterMaxHealth maxHealth) 
            {
                _maxHealth = maxHealth;
                _maxHealth.AddListener(OnMaxHealthChanged);
                _lastMaxHealth = maxHealth.Value;
            }

            public void SetValue(float value) => Value = value;

            public bool TryMakeDamage(float damage)
            {
                Value -= damage;
                return Value > Min;
            }

            private void OnMaxHealthChanged(float obj)
            {
                if (_maxHealth.Value > _lastMaxHealth)
                {
                    Value += _maxHealth.Value - _lastMaxHealth;
                }
                else Value = Value;

                _lastMaxHealth = _maxHealth.Value;
            }
        }


        #endregion

        #region Save

        public class ParameterSave : Core.DataSaveValueInt<ParameterSave>
        {
            protected override int Min => 0;
            protected override int Max => 9999999;
            protected override int data
            {
                get => GameSaveDataExample.SaveValue;
                set => GameSaveDataExample.SaveValue = value;
            }

            public ParameterSave() { }

            public void Reset() => Value = GameSaveDataExample.SaveDefault;

            public void Add(int value) => Value += value;

            public bool TrySpend(int value)
            {
                if (Value >= value)
                {
                    Value -= value;
                    return true;
                }
                else return false;
            }
        }

        public class ParameterGold : Core.DataSaveValueInt<ParameterGold>
        {
            protected override int Min => 0;
            protected override int Max => 9999999;
            protected override int data
            {
                get => GameSaveData.GoldValue;
                set => GameSaveData.GoldValue = value;
            }

            public ParameterGold() { }

            public void Reset() => Value = GameSaveData.GoldDefault;

            public void Add(int value) => Value += value;

            public void Set(int value) => Value = value;

            public bool TrySpend(int value)
            {
                if (Value >= value)
                {
                    Value -= value;
                    return true;
                }
                else return false;
            }
        }

        #endregion
    }
}