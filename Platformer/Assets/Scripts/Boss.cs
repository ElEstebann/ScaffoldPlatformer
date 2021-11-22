using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    /// <summary>
    /// Patrol takes a GameObject and makes such object to patrol specified locations at the given speed
    /// </summary>

    public float moveSpeed; //Patrol speed
    public float jumpSpeed;
    public float jumpHeight;

    [Header("Agent's patrol areas")]
    public List<Transform> patrolLocations; //List of all the Transform locations the gameObject will patrol

    [Space]
    [Header("Agent")]
    public GameObject patrollingGameObject; //Unity GameObject that patrols
    public GameObject patrollingGameObjectUI;
    public float transitionDelay;
    private int nextPatrolLocation; //Keeps track of the patrol location
    private bool canAct = true;
    private bool actionCompleted = true;
    private int functionNum = 0;

    // Update is called once per frame
    void Update()
    {
        callRightFunction();

    }

    private void callRightFunction()
    {
        if (actionCompleted)
        {
            functionNum = 0;
            actionCompleted = false;
            StartCoroutine(actionTimer());
        }
        else
        {


            if (functionNum == 0)
            {

            }

            else if (functionNum == 1)
            {
                PatrolArea();
            }
            else if (functionNum == 2)
            {
                JumpArea();
            }
        }


    }
    private void charge()
    {
        actionCompleted = false;
        while (!actionCompleted)
        {
            Debug.Log("Patrolling");
            PatrolArea();
        }
    }

    //Moves the patrollingGameObject towards patrol location, when reach destination switch to next patrol position in the list
    private void PatrolArea()
    {
        Flip();
        patrollingGameObject.transform.position = Vector2.MoveTowards(patrollingGameObject.transform.position,
            patrolLocations[nextPatrolLocation].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(patrollingGameObject.transform.position, patrolLocations[nextPatrolLocation].position) <= 2)
        {
            nextPatrolLocation = (nextPatrolLocation + 1) % patrolLocations.Count;//Prevents IndexOutofBound by looping back through list
            actionCompleted = true;
            Debug.Log("PatrollArea completed, waiting " + transitionDelay + "seconds");
            Flip();
        }
    }
    private void JumpArea()
    {
        Flip();
        float posy = patrolLocations[nextPatrolLocation].position.y;
        float posx = patrollingGameObject.transform.position.x;
        float x1 = patrolLocations[0].position.x + 2;
        float x2 = patrolLocations[1].position.x - 2;
        float current_y = patrollingGameObject.transform.position.y;
        current_y = posy - (jumpHeight * (posx - x1) * (posx - x2));

        patrollingGameObject.transform.position = new Vector2(patrollingGameObject.transform.position.x, posy);

        patrollingGameObject.transform.position = Vector2.MoveTowards(patrollingGameObject.transform.position,
            patrolLocations[nextPatrolLocation].position, jumpSpeed * Time.deltaTime);



        if (Vector2.Distance(patrollingGameObject.transform.position, patrolLocations[nextPatrolLocation].position) <= 2)
        {
            nextPatrolLocation = (nextPatrolLocation + 1) % patrolLocations.Count;//Prevents IndexOutofBound by looping back through list
            actionCompleted = true;
            patrollingGameObject.transform.position = new Vector2(patrollingGameObject.transform.position.x, posy);
            Debug.Log("JumpArea completed, waiting " + transitionDelay + "seconds");
            Flip();
        }
        else
        {
            patrollingGameObject.transform.position = new Vector2(patrollingGameObject.transform.position.x, current_y);
        }

    }

    //Makes the patrollingGameObject always be facing the next patrol location
    private void Flip()
    {
        Vector2 localScale = patrollingGameObject.transform.localScale;
        if (patrollingGameObject.transform.position.x - patrolLocations[nextPatrolLocation].position.x > 0)
            localScale.x = 1;
        else
            localScale.x = -1;
        patrollingGameObject.transform.localScale = localScale;

        patrollingGameObjectUI.transform.localScale = localScale;

    }
    IEnumerator actionTimer()
    {

        yield return new WaitForSeconds(transitionDelay);

        functionNum = Random.Range(1, 3);
        //functionNum = 2;
        Debug.Log("Delay over, functionNum set to: " + functionNum);


    }
}
