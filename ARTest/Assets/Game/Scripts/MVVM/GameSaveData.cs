using MVVM.Data;

namespace MVVM.Game.Data
{
    public class GameSaveData : MVVMSaveData
    {
        public static int SaveValue
        {
            get => LoadInt(SaveLink, SaveDefault);
            set => SaveInt(SaveLink, value);
        }
        public const int SaveDefault = 0;
        private const string SaveLink = "Save_Value";

        public static int GoldValue
        {
            get => LoadInt(GoldLink, GoldDefault);
            set => SaveInt(GoldLink, value);
        }
        public const int GoldDefault = 0;
        private const string GoldLink = "Gold_Value";
    }
}