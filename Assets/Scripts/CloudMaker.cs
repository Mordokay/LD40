using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour {

    public List<Transform> spawnPoints;
    GameObject[] clouds;

    List<float> LastSpawnPointTime;
    public float cloudSpeedMin;
    public float cloudSpeedMax;

    void Start () {
        clouds = Resources.LoadAll<GameObject>("Clouds");
        LastSpawnPointTime = new List<float>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            LastSpawnPointTime.Add(Random.Range(0.0f, 6.0f));
        }
        InitialCloudSpawn();
    }
	
    void InitialCloudSpawn()
    {
        for(int i = -12; i <= 45; i = i + 3)
        {
            float lastXPos = -12.0f;
            while(lastXPos < 120)
            {
                GameObject myCloud = Instantiate(clouds[Random.Range(0, clouds.Length)], transform) as GameObject;
                myCloud.transform.position = new Vector3(lastXPos, i + Random.Range(-1.5f, 1.5f), 0.0f);
                //myCloud.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(cloudSpeedMin, cloudSpeedMax));

                lastXPos += Random.Range(8.0f, 12.0f);
            }
        }
    }

	void Update () {
        /*
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            LastSpawnPointTime[i] -= Time.deltaTime;
            if(LastSpawnPointTime[i] < 0.0f)
            {
                LastSpawnPointTime[i] = Random.Range(5.0f, 10.0f);
                GameObject myCloud = Instantiate(clouds[Random.Range(0, clouds.Length)], transform) as GameObject;
                myCloud.transform.position = spawnPoints[i].position;
                myCloud.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(cloudSpeedMin, cloudSpeedMax));
            }
        }
        */
    }
}
