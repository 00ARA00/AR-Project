using MVVM.Data;

namespace MVVM.Example.Data
{
    public class GameSaveDataExample : MVVMSaveData
    {
        public static int SaveValue
        {
            get => LoadInt(SaveLink, SaveDefault);
            set => SaveInt(SaveLink, value);
        }
        public const int SaveDefault = 0;
        private const string SaveLink = "Save_Value";
    }   
}