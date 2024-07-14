using System;

namespace SkillsSystem.MVVMCore
{
    public abstract class SSSkill : IDisposable
    {
        public SSSkill(SSModel model)
        {
            Model = model;
            Model.OnSkillSavesChanged += OnSkillSavesChanged;
            _isActive = false;
        }

        protected readonly SSModel Model;

        public bool ReadOnly { get; protected set; }

        public abstract int SkillID { get; }
        public abstract int MaxLevel { get; }
        public abstract bool CanOpen { get; }

        public virtual int NextLevelCost => 0;
        public virtual bool CanLevelUp => SkillLevel < MaxLevel;
        public virtual bool IsOpen => SkillLevel > 0;

        public virtual int SkillLevel => Model.GetSkillLevel(SkillID);

        public bool IsAcitve
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    if (_isActive) SwitchOnSkill();
                    else SwitchOffSkill();
                }
            }
        }

        private bool _isActive;

        public void Dispose() => Model.OnSkillSavesChanged -= OnSkillSavesChanged;

        protected virtual void OnSkillSavesChanged()
        {
            if (IsAcitve)
            {
                SwitchOffSkill();
                SwitchOnSkill();
            }
        }

        public virtual bool TryLevelUp()
        {
            if (CanLevelUp)
            {
                Model.LevelUp(SkillID);
                return true;
            }
            else return false;
        }

        protected virtual void SwitchOnSkill() { }
        protected virtual void SwitchOffSkill() { }
    }
}