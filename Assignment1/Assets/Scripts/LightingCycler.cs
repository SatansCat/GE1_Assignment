using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingCycler : MonoBehaviour
{
    private Light WorldLight;
    private int Looper = 0;

    private void OnEnable()
    {
        WorldLight = gameObject.GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Looper += (int) Time.deltaTime;
        if (Looper == 361)
        {
            Looper = 0;
        }
        WorldLight.color =  Color.HSVToRGB(Looper, 16, 100);

    }
}
