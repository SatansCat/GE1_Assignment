using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    //Stat Tracker
    public int Health;
    public int Score;

    private void OnEnable()
    {
        Health = 5;
        Score = 0;
    }
}
