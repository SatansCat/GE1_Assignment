using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManipulator : MonoBehaviour
{
    public CoreScript Core;
    List<GameObject> Enemies = new List<GameObject>();
    public GameObject TurretPrefab;
    public GameObject doorIn;
    public GameObject doorOut;

    public int totalEnemies = 1;
    public int toKill;

    private void Awake()
    {
        toKill = totalEnemies;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(TurretPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Enemies.Add(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if(toKill <1 && doorOut.activeInHierarchy)
        {
            Core.NextMap();
            doorOut.SetActive(false);
            //Stop music
        }
        else
        {
            foreach(GameObject enemy in Enemies)
            {
                if(enemy.GetComponent<ObjectHealth>().Health <1)
                {
                    Enemies.Remove(enemy);
                    Destroy(enemy);
                    toKill--;
                }
            }
        }
    }

    public void Entered()
    {
        doorIn.SetActive(true);
        Core.RemoveMap();
        //Start the show.
    }
}
