using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class snake : MonoBehaviour {

    bool ate = false;
    public GameObject snake_tail;
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();

    // Use this for initialization
    void Start () {
        InvokeRepeating("Movement", 0.5f, 0.5f);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("food"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    void Movement()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(snake_tail,v,Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
