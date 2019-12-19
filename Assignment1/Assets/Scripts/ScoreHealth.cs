using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHealth : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Hearts;
    public GameObject Level;
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Hearts.Length - Player.GetComponent<StatTracker>().Health; i++)
        {
            Hearts[i].SetActive(false);
        }

        Level.GetComponent<Text>().text = "Level: " + Player.GetComponent<StatTracker>().Score;

        if(Player.GetComponent<StatTracker>().Health <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
