using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceStats : MonoBehaviour
{
    [SerializeField] private Transform[] diceSides;
    [SerializeField] private Rigidbody diceRigidbody;

    private bool _isDiceStationary;
    private int _side = 1;

    public int Side => _side;
    public bool IsDiceStationary => _isDiceStationary;

    private void Update()
    {
        CheckDiceSide();
        CheckDiceCondition();
    }

    private void CheckDiceSide()
    {
        for (int i = 0; i < diceSides.Length; i++)
        {
            if (diceSides[i].position.y > diceSides[_side - 1].position.y)
            {
                _side = i + 1;
            }
        }
    }

    private void CheckDiceCondition()
    {
        if (diceRigidbody.velocity.magnitude < 0.01f && diceRigidbody.angularVelocity.magnitude < 0.01f)
        {
            _isDiceStationary = true;
        }
    }
}
