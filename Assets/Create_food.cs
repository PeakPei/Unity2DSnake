using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_food : MonoBehaviour {

    // Use this for initialization
    public GameObject food;

    public Transform border_Top;
    public Transform border_Down;
    public Transform border_Left;
    public Transform border_Right;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Create", 3, 5);
    }
    void Create()
    {
        int x = (int)Random.Range(border_Left.position.x,
                                  border_Right.position.x);

        int y = (int)Random.Range(border_Down.position.y,
                                  border_Top.position.y);

        Instantiate(food,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
