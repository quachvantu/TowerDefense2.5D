using System;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private int currentGold;
    public void AddGold(int amount)
    {
        currentGold += amount;
        Debug.Log(currentGold);
    }
}
