using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour {

    public List<GameObject> AllStars;
    public Sprite GoldStar;
    public GameObject winPanel;

    UIManager uiManager;
    public GameObject gameHolder;

    private void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            int totalCount = 0;
            for(int i = 0; i < AllStars.Count; i++)
            {
                if (uiManager.activatedStars[i])
                {
                    totalCount += 1;
                    AllStars[i].GetComponent<SpriteRenderer>().color = Color.yellow;
                }
            }
            if(totalCount == 9)
            {
                //Debug.Log("Player won the game!!!!");
                uiManager.ResetData();
                winPanel.SetActive(true);
                gameHolder.SetActive(false);
            }
            else
            {
                //Debug.Log("Only got " + totalCount + " stars!!!");
            }
        }
    }

}
