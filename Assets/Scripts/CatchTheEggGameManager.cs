using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchTheEggGameManager : MonoBehaviour
{
    public static CatchTheEggGameManager instance;
    public GameObject eggPrefab;
    public Transform basket;

    public int score = 0;
    public TMP_Text scoreText;
    public float speed;
    private void Awake()
    {
        instance = this;
    }
    public List<Transform> spawnPoints = new();

    public bool controlsEnabled = true;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEggs), 2f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            if(Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
            {
                if(basket.transform.position.x > -6)
                {
                    basket.position += new Vector3(-speed, 0f, 0f);
                }
            }
            else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (basket.transform.position.x < 6)
                {
                    basket.position += new Vector3(speed, 0f, 0f);
                }
            }
        }
    }

    public void SpawnEggs()
    {
        int n = Random.Range(0, spawnPoints.Count);
        Instantiate(eggPrefab, spawnPoints[n].position, Quaternion.identity);
    }

    public void UpdateScore(int n)
    {
        score += n;
        scoreText.text = $"Score: {score}";
    }
}
