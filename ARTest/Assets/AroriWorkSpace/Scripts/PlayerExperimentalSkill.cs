using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperimentalSkill : PlayerSkill
{
    private PlayerInputSystem _inputSystem;

    public override void Initialize(PlayerInitializer playerInitializer)
    {
        //_inputSystem = playerInitializer.PlayerInputSystem;
        //_inputSystem.OnStartBattleButtonClick += OnStartBattleButtonClick;
    }

    private void OnStartBattleButtonClick()
    {
        throw new NotImplementedException();
    }
}
