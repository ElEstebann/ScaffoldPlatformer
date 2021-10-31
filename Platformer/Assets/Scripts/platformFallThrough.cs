using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformFallThrough : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D effector;
    public float waitTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    
 
    void Update()
    {
        if(Input.GetButtonUp("Down")){
            waitTime = 0f;
        }

        if(Input.GetButton("Down")){
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetButton("Jump")){
            effector.rotationalOffset = 0f;
        }
    }
}
