using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsProperty : MonoBehaviour
{
    public GameObject mainThread;
    public int id;
    public float r;
    private Rigidbody2D rb2D;

    // Input
    private bool rightForce;
    private bool leftForce;
    private bool upForce;
    private bool downForce;

    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // detect input
        rightForce = Input.GetKey(KeyCode.D);
        leftForce = Input.GetKey(KeyCode.A);
        upForce = Input.GetKey(KeyCode.W);
        downForce = Input.GetKey(KeyCode.S);

        if (rightForce) rb2D.AddForce(new Vector3(r, 0.0f, 0.0f));
        if (leftForce) rb2D.AddForce(new Vector3(-r, 0.0f, 0.0f));
        if (upForce) rb2D.AddForce(new Vector3(0.0f, r, 0.0f));
        if (downForce) rb2D.AddForce(new Vector3(0.0f, -r, 0.0f));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<DropsProperty>()){
            if(this.r >= other.gameObject.GetComponent<DropsProperty>().r){
                this.r = this.r+other.gameObject.GetComponent<DropsProperty>().r/2;
                this.gameObject.transform.localScale = new Vector2(this.r, this.r);
            }else{
                Destroy(this.gameObject);
            }
        }
    }
}
