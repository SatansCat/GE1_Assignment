using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManipulator : MonoBehaviour
{
    public CoreScript Core;
    List<GameObject> Enemies = new List<GameObject>();
    public GameObject EnemyPrefab;
    public GameObject doorIn;
    public GameObject doorOut;
    public GameObject[] Blockers;
    public GameObject[] Turrets;
    public GameObject[] Stretchers;

    public AudioSource chosenSong; //Song chosen for map.
    public static int frameSize = 512;
    public float[] samples = new float[frameSize];
    public float[] bands;
    public float binWidth;
    public float sampleRate;

    public int totalEnemies = 1;
    public int toKill;
    public int SpawnRate;
    public bool isIn = false;
    public GameObject Player;

    private void Awake()
    {
        toKill = totalEnemies;
        bands = new float[(int)Mathf.Log(frameSize, 2)];
    }

    void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    // Start is called before the first frame update
    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;
    }

    // Update is called once per frame
    void Update()
    {

        GetSpectrumAudioSource();

        //Effects for map
        if (bands[1] <= .2f)
        {
            for(int i=0; i<Blockers.Length; i++)
            {
                Blockers[i].GetComponent<BoxCollider2D>().enabled = true;
                Blockers[i].GetComponent<SpriteRenderer>().color = new Color(219f/255, 216f/255, 0f);
            }
        }
        else
        {
            for (int i = 0; i < Blockers.Length; i++)
            {
                Blockers[i].GetComponent<BoxCollider2D>().enabled = false;
                Blockers[i].GetComponent<SpriteRenderer>().color = new Color(90f/255, 88f/255, 94f/255);
            }
        }

        if (bands[4] >= .2f)
        {
            for (int i = 0; i < Turrets.Length; i++)
            {
                Turrets[i].GetComponent<TurretShooting>().Shoot();
            }
        }

        for(int i = 0; i<Stretchers.Length; i++)
        {
            Stretchers[i].transform.localScale = new Vector3(.1f, bands[7 - i], 1);
        }

        
        
        if(!chosenSong.isPlaying && doorOut.activeInHierarchy && isIn)
        {
            Core.NextMap();
            doorOut.SetActive(false);
            //Stop music
        }
        else
        {
            if(Enemies.Count > 0)
            {
                
                foreach (GameObject enemy in Enemies)
                {
                    if(enemy.GetComponent<ObjectHealth>().Health <1)
                    {
                        print("Reached: ");
                        Enemies.Remove(enemy);
                        Destroy(enemy);
                        //toKill--;
                    }
                }
            }
            
        }
    }


    //Enemy Spawning
    IEnumerator Spawn()
    {
        
        while (true)
        {
            if (bands[5] >= .3f)
            {
                
                Vector3 newpos = gameObject.transform.position + new Vector3(Random.Range(-7, 7), Random.Range(-7, 7), 0);
                GameObject temp = Instantiate(EnemyPrefab, newpos, gameObject.transform.rotation, gameObject.transform);
                temp.GetComponent<EnemyFollow>().Player = Player;
            
                Enemies.Add(temp);
                yield return new WaitForSeconds(1.0f / SpawnRate);
            }
            yield return null;
        }
    }



    public void Entered()
    {
        doorIn.SetActive(true);
        Core.RemoveMap();
        //Start the show.
        chosenSong.Play();
        isIn = true;
    }

    void GetFrequencyBands()
    {
        for(int i=0; i<bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;
            for(int j=start; j<end; j++)
            {
                average += samples[j] * (j + 1);
            }
            average /= (float)width;
            bands[i] = average;
        }
    }

    void GetSpectrumAudioSource()
    {
        chosenSong.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        GetFrequencyBands();
    }
}
