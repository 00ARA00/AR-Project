using Gameplay.Heroes;
using PoolsContainer.Core;
using System;

namespace PoolsContainer
{
    public class HeroesPool : MonoPool, IObjectCreator<HeroInitializer>
    {
        event Action<HeroInitializer> IObjectCreator<HeroInitializer>.OnCreated
        {
            add => OnHeroCreated += value;
            remove => OnHeroCreated -= value;
        }
        public event Action<HeroInitializer> OnHeroCreated;

        protected override void Created(object prefab, PoolObject obj)
        {
            if (obj.TryGetComponent(out HeroInitializer hero))
                OnHeroCreated?.Invoke(hero);
        }
    }
}