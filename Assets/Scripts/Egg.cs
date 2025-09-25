using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float speed;
    public Sprite broken;
    SpriteRenderer sp;
    BoxCollider2D bx;
    public bool stopped = false;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!stopped)
            transform.position += new Vector3(0f, -speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            stopped = true;
            sp.sprite = broken;
            transform.localScale = Vector3.one * 1.2f;
            bx.enabled = false;
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("Basket"))
        {
            stopped = true;
            CatchTheEggGameManager.instance.UpdateScore(10);
            Destroy(gameObject);
        }
    }
}
