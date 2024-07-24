using MVVM.Core;

namespace MVVM.Game
{
    public class GameVM : MVVMViewModel<GameModel>
    {
        public static GameVM Instance
        {
            get { return _instance ?? (_instance = new GameVM()); }
        }
        private static GameVM _instance;

        protected override GameModel CreateModel() => new GameModel();
    }
}