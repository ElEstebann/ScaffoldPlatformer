using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] public float fireDelay;
    private bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !shooting)//if Player hits the weakspot then
        {
            //Debug.Log(collision.transform.position.x);
            ShootAtTarget(collision.transform);
            StartCoroutine(bulletTimer());
        }
    }
    void ShootAtTarget(Transform target)
    {
        Vector3 targ = target.transform.position;
        targ.z = 0f;
 
        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        firePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //firePoint.transform.Rotate(0,0,Vector2.Angle(target.position,firePoint.position));
        Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        //Debug.Log("Angle: " + Vector2.Angle(target.position,firePoint.position));
        //firePoint.transform.Rotate(0,0,Vector2.Angle(target.position,firePoint.position) * -1);
    }

    IEnumerator bulletTimer(){
        shooting = true;

        yield return new WaitForSeconds(fireDelay);
        shooting = false;
    }
}
