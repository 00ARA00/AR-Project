using Gameplay.Heroes;
using PoolsContainer.Core;

namespace PoolsContainer.Example
{
    public class HeroesContainer : MonoSingleContainer<HeroInitializer>
    {
        protected override void Created(HeroInitializer obj)
        {

        }
    }
}