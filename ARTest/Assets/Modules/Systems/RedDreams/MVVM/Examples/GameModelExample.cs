using MVVM.Core;
using MVVM.Data;
using MVVM.Example.Data;

namespace MVVM.Example
{
    public class GameModelExample : MVVMModel
    { 
        protected override void InitializeDatas()
        {
            var parameterDefault = new ParameterDefault();
            var parameterSave = new ParameterSave(); 
            
            DataMap.Add(typeof(ParameterDefault), parameterDefault);
            DataMap.Add(typeof(ParameterSave), parameterSave);
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

        #endregion
    }
}