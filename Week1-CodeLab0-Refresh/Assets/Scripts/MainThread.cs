using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainThread : MonoBehaviour
{
    public GameObject Drop;
    public int totalDropsAmount = 10;
    public static bool GameStarted; // To prevent from vanishing when generating drops
    public static int score = 0;
    public GameObject scoreText;

    private SpriteRenderer sr;
    private int dropsCount;

    // Start is called before the first frame update
    void Start()
    {   
        Screen.SetResolution(1920, 1080, true, 60);
        dropsCount = 0;
        scoreText.GetComponent<Text>().text = score.ToString();
        for (; dropsCount < totalDropsAmount; dropsCount++) {
            Drop.GetComponent<DropsProperty>().id = dropsCount;
            Drop.GetComponent<DropsProperty>().r = Random.Range(50.0f, 150.0f);
            Drop.transform.localScale = new Vector2(Drop.GetComponent<DropsProperty>().r, Drop.GetComponent<DropsProperty>().r);
            Instantiate(Drop, new Vector3(Random.Range(200.0f, 1600.0f), Random.Range(100.0f, 800.0f), 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = score.ToString();
    }
}