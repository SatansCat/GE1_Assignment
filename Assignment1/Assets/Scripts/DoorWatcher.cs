using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWatcher : MonoBehaviour
{
    public MapManipulator Map;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Map.Entered();
            gameObject.SetActive(false);
        }
    }
}
