using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public GameObject enemy;
    public Vector2 center;

    // Start is called before the first frame update
    void Start()
    {
        center = new Vector2(enemy.transform.position.x - 3, enemy.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center, Vector3.forward, 100 * Time.deltaTime);
        transform.rotation = Quaternion.identity;
        
    }
}
