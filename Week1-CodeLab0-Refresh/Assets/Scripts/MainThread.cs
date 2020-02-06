using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThread : MonoBehaviour
{
    public GameObject Drop;
    public int totalDropsAmount = 10;
    public static int dropsCount;
    public static bool GameStarted; // To prevent from vanishing when generating drops
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {   
        dropsCount = 0;
        for (; dropsCount < totalDropsAmount; dropsCount++) {
            Drop.GetComponent<DropsProperty>().id = dropsCount;
            Drop.GetComponent<DropsProperty>().r = Random.Range(0.5f, 1.0f);
            Drop.transform.localScale = new Vector2(Drop.GetComponent<DropsProperty>().r, Drop.GetComponent<DropsProperty>().r);
            Instantiate(Drop, new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}