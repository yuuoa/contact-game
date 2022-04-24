using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSize : MonoBehaviour
{
    public Text BoundX, BoundY;
    Vector2 MapSize;
    // Start is called before the first frame update
    void Start()
    {
        MapSize = GetComponent<Renderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        BoundX.text = ("Bound X: " + MapSize.x);
        BoundY.text = ("Bound Y: " + MapSize.y);
    }
}
