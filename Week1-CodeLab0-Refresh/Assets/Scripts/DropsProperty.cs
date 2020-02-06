﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsProperty : MonoBehaviour
{
    public GameObject mainThread;
    public int id;
    public float r;
    private Rigidbody2D rb2D;
    private bool willShrink = false;
    float deltaX;
    float deltaY;
    private Vector2 collidePosition;
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

        if (rightForce || leftForce || upForce || downForce && !MainThread.GameStarted) {
            MainThread.GameStarted = true;
            //rb2D.isKinematic = true;
        }

        if (rightForce) rb2D.AddForce(new Vector3(r, 0.0f, 0.0f));
        if (leftForce) rb2D.AddForce(new Vector3(-r, 0.0f, 0.0f));
        if (upForce) rb2D.AddForce(new Vector3(0.0f, r, 0.0f));
        if (downForce) rb2D.AddForce(new Vector3(0.0f, -r, 0.0f));

        if (willShrink){
            this.r -= Mathf.Sqrt(Mathf.Pow(deltaX, 2)+Mathf.Pow(deltaY, 2))*Mathf.Pow(this.r, 2);
            this.gameObject.transform.localScale = new Vector2(this.r, this.r);
            this.transform.Translate(deltaX*Mathf.Pow(this.r, 2), deltaY*Mathf.Pow(this.r, 2), 0.0f);
            if (this.r<=0.0f) Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!MainThread.GameStarted) return;
        if (other.gameObject.GetComponent<DropsProperty>()){
            // collide with other drops
            if(this.r >= other.gameObject.GetComponent<DropsProperty>().r){
                this.r += other.gameObject.GetComponent<DropsProperty>().r/2;
                this.gameObject.transform.localScale = new Vector2(this.r, this.r);
            }else{
                willShrink = true;
                float ratio = this.r/(this.r+other.gameObject.GetComponent<DropsProperty>().r);
                deltaX = (other.gameObject.transform.position.x - this.transform.position.x) * ratio;
                deltaY = (other.gameObject.transform.position.y - this.transform.position.y) * ratio;
            }
        }else{
            // collide with walls
            // Destroy(this.gameObject);
        }
    }
}
