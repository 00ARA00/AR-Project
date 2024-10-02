using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiceHighlight : MonoBehaviour
{
    [SerializeField] private GameObject[] sides;
    [SerializeField] private DiceStats _diceStats;

    private void Update()
    {
        HighlightSides();
    }

    private void HighlightSides()
    {
        for(int i = 0; i<sides.Length; i++)
        {
            sides[i].SetActive(false);
        }

        sides[_diceStats.Side - 1].SetActive(true);
    }
}
