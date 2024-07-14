using UnityEngine;
using UnityEngine.UI;

namespace Game.Audio
{
    public class ButtonPlayerAudio : PlayAudio
    {
        private Button _button;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        public void OnButtonClick() => Play();
    }
}