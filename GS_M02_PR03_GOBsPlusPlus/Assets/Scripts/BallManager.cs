using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;

    public GameObject holdBall;
    public GameObject holdWater;
    public GameObject footBallPrefab;


    Pursuer pursuer;
    Rigidbody rb;
    SphereCollider sphereCollider;

    void Start()
    {
        ball.GetComponent<Pursuer>().enabled = false;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.GetComponent<Rigidbody>().useGravity = false;

        holdBall.SetActive(false);
        holdWater.SetActive(false);

        ResetBallTransform();
    }

    public void BlockShot()
    {
        holdWater.SetActive(false);
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Pursuer>().enabled = true;
        ball.GetComponent<Rigidbody>().useGravity = true;
    }

    public void DrinkWater()
    {
        holdBall.SetActive(false);
        holdWater.SetActive(true);
    }

    public void ScoreGoal()
    {
        holdBall.SetActive(false);
        holdWater.SetActive(false);

        GameObject newBall = Instantiate(footBallPrefab, this.transform);
        newBall.transform.parent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ResetBallTransform();
            holdBall.SetActive(true);
        }
    }

    public void ResetBallTransform()
    {
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.GetComponent<Pursuer>().enabled = false;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.transform.position = new Vector3(0f, 4f, 18f);
    }

}
