using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class mainScript : MonoBehaviour
{

    public bool movementDetectionActive;
    private bool lastWasActive;

    public float timeFreq = 0.1f;
    public float Tolerance = 5f;

    public GameObject GOleftHand;
    public GameObject GOrightHand;

    private Vector3 lastPositionLeft;
    private Vector3 lastPositionRight;

    public GameObject GOscore;

    private int score;

    private float lastTime;


    /* */
    // Start is called before the first frame update
    void Start()
    {
        lastWasActive = false;
        score = 0;
    }

    public void switchOn()
    {
        movementDetectionActive = true;
    }

    public void switchOff()
    {
        movementDetectionActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        if((movementDetectionActive)&&(lastWasActive==false))
        {
            lastPositionLeft = GOleftHand.transform.position;
            lastPositionRight = GOrightHand.transform.position;
            lastTime = Time.time;
            lastWasActive = true;
        }


        if(movementDetectionActive)
        {
            if (Time.time - lastTime > timeFreq)
            {
                Vector3 positionLeft;
                Vector3 positionRight;

                positionLeft = GOleftHand.transform.position;
                positionRight = GOrightHand.transform.position;

                float distanceLeft = Vector3.Distance(positionLeft, lastPositionLeft);
                float distanceRight = Vector3.Distance(positionRight, lastPositionRight);

                lastPositionLeft = positionLeft;
                lastPositionRight = positionRight;
                lastTime = Time.time;

                Debug.Log((distanceLeft + distanceRight) / 2.0f);

                if ((distanceLeft+distanceRight)/2.0f > Tolerance)
                {
                    score++;
                    GOscore.GetComponent<TextMeshPro>().text = "SCORE: " + score;
                }
            }
            

        } else
        {
            lastWasActive = false;
        }
    }

   
}
