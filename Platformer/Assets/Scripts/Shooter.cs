using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePointRight;
    public Transform firePointLeft;
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointUpRight;
    public Transform firePointDownRight;
    public Transform firePointUpLeft;
    public Transform firePointDownLeft;
    public GameObject bulletPrefab;
    private bool shooting = false;
    public float shootDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("FireRight")){
            if(Input.GetButton("FireUp"))
            {
                if(!shooting)
                {
                    ShootUpRight();
                    StartCoroutine(bulletTimer());
                }
            }
            else if(Input.GetButton("FireDown"))
            {
                if(!shooting)
                {
                    ShootDownRight();
                    StartCoroutine(bulletTimer());
                }
            }
            else{
                if(!shooting)
                {
                    ShootRight();
                    StartCoroutine(bulletTimer());
                }
            }
            
        }
        else if(Input.GetButton("FireLeft")){
            if(Input.GetButton("FireUp"))
            {
                if(!shooting)
                {
                    ShootUpLeft();
                    StartCoroutine(bulletTimer());
                }
            }
            else if(Input.GetButton("FireDown"))
            {
                if(!shooting)
                {
                    ShootDownLeft();
                    StartCoroutine(bulletTimer());
                }
            }
            else{
                if(!shooting)
                {
                    ShootLeft();
                    StartCoroutine(bulletTimer());
                }
            }
        }
        else if(Input.GetButton("FireUp")){
            if(!shooting)
            {
                ShootUp();
                StartCoroutine(bulletTimer());
            }
        }
        else if(Input.GetButton("FireDown")){
            if(!shooting)
            {
                ShootDown();
                StartCoroutine(bulletTimer());
            }
        }
    }  

    void ShootRight()
    {
        Instantiate(bulletPrefab,firePointRight.position, firePointRight.rotation);
    }
    void ShootLeft()
    {
        Instantiate(bulletPrefab,firePointLeft.position, firePointLeft.rotation);
    }

    void ShootDown()
    {
        Instantiate(bulletPrefab,firePointDown.position, firePointDown.rotation);
    }

    void ShootUp()
    {
        Instantiate(bulletPrefab,firePointUp.position, firePointUp.rotation);
    }

    void ShootUpRight()
    {
        Instantiate(bulletPrefab,firePointUpRight.position, firePointUpRight.rotation);
    }
    void ShootUpLeft()
    {
        Instantiate(bulletPrefab,firePointUpLeft.position, firePointUpLeft.rotation);
    }
    void ShootDownRight()
    {
        Instantiate(bulletPrefab,firePointDownRight.position, firePointDownRight.rotation);
    }
    void ShootDownLeft()
    {
        Instantiate(bulletPrefab,firePointDownLeft.position, firePointDownLeft.rotation);
    }
    
    IEnumerator bulletTimer(){
        shooting = true;

        yield return new WaitForSeconds(shootDelay);
        shooting = false;
    }
}   
