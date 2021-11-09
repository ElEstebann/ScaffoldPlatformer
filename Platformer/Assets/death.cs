using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>(); //get animator component
    }
}