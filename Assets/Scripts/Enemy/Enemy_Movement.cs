using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject player;
    public GameObject swarm;
    public float speed;
    public float stopDistance = 3;
    private float distance;
    private bool facingRight = true;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character-i");
        swarm = GameObject.Find("EnemySpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }else{
            this.gameObject.SetActive(false);
         }

    }
    private void FixedUpdate()
    {
        //Flip 
        //if facing left and moveming to the right Flip function flips Sprite to the right
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        //if facing right and moving to the left Flip function flips Sprite to the left
        if (direction.x< 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        //Sprite scale(which happens to be defined as localScale) is set to currentScale
        Vector3 currentScale = transform.localScale;
        //if Flip is called then it changes what ever the Scale is to negative therefore fliping the Sprite horizontally
        currentScale.y *= -1;
        transform.localScale = currentScale;
        //flips bool to true if false and vice-versa
        facingRight = !facingRight;
    }
}
