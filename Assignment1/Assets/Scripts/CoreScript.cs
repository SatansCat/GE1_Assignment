using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{
    List<GameObject> Maps = new List<GameObject>();
    List<GameObject> Paths = new List<GameObject>();
    public GameObject StartingMap;
    public GameObject StartingPath;
    public GameObject MapPrefab;
    public GameObject PathPrefab;

    public GameObject Player;

    public AudioSource[] Songs;

    // Start is called before the first frame update
    void Start()
    {
        Maps.Add(StartingMap);
        StartingMap.GetComponent<MapManipulator>().chosenSong.Play();
        StartingMap.GetComponent<MapManipulator>().isIn = true;
        Paths.Add(StartingPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextMap()
    {
        Vector3 newMapPos = Maps[0].transform.position + new Vector3(0, 34, 0);
        GameObject newMap = Instantiate(MapPrefab, newMapPos, Maps[0].transform.rotation);

        Vector3 newPathPos = Maps[0].transform.position + new Vector3(0, 51, 0);
        GameObject newPath = Instantiate(PathPrefab, newPathPos, Maps[0].transform.rotation);

        newMap.GetComponent<MapManipulator>().Core = this;
        int i = Random.Range(0, 3);
        newMap.GetComponent<MapManipulator>().chosenSong = Songs[i];
        newMap.GetComponent<MapManipulator>().Player = Player;
        Maps.Add(newMap);
        Paths.Add(newPath);
    }

    public void RemoveMap()
    {
        GameObject ToRemove = Maps[0];
        Maps.Remove(ToRemove);
        Destroy(ToRemove);

        ToRemove = Paths[0];
        Paths.Remove(ToRemove);
        Destroy(ToRemove);
    }
}
