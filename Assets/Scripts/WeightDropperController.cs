using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDropperController : MonoBehaviour {

    public GameObject weightPrefab;
    public List<Transform> spawnPoints;

    float remainingTimeForDrop;
    GameObject canvas;

	void Start () {
        remainingTimeForDrop = Random.Range(5.0f, 10.0f);
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
	
	void Update () {
        if (canvas.GetComponent<TabManager>().homeTabSelected)
        {
            remainingTimeForDrop -= Time.deltaTime;
            if (remainingTimeForDrop < 0.0f)
            {
                GameObject myWeight = Instantiate(weightPrefab, gameObject.transform.parent);
                myWeight.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
                remainingTimeForDrop = Random.Range(5.0f, 10.0f);
            }
        }
    }
}
