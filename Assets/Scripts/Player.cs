using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 2f;

    bool haveWand = false;

    public GameObject chickenText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //store current position as a new vector3 variable
        Vector3 newPos = transform.position;

        //if WASD is pressed
        if (Input.GetKey(KeyCode.W))
        {
            //increase the newPos y number by speed
            newPos.y += speed * Time.deltaTime;
            //Debug.Log(transform.position.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //decrease the newPos y number by speed
            newPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //decrease the newPos x number by speed
            newPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //increase the newPos x number by speed
            newPos.x += speed * Time.deltaTime;
        }

        //set the gameobject's position to the new position
        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.transform.position);
        if(other.gameObject.name == "Wand")
        {
            haveWand = true;
            Destroy(other.gameObject);
        }
        if (haveWand && other.gameObject.name == "Enemy")
        {
            Destroy(other.gameObject);
        } else if(!haveWand && other.gameObject.name == "Enemy")
        {
            chickenText.SetActive(true);
        }
    }

}
