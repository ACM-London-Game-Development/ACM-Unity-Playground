using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Move))]
public class PlayerMode : MonoBehaviour
{
    //BallGrabber ballGrabber;
    //bool shooting = false;
    Transform shooterArrow;
    //Rigidbody2D rb2d;
    Vector2 ballDir = Vector2.zero;
    Move move;

    public float shootForce = 5.0f;
    public int possessionSpeed = 3;
    public int moveSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        shooterArrow = transform.Find("ShooterArrow");
        //rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Transform ball, Rigidbody2D ballRb2d, float shotPower)
    {
        ballRb2d.AddForce(ballDir * shotPower, ForceMode2D.Impulse);
    }

    public void SwitchMode(bool shoot)
    {
        if (shoot)
        {
            shooterArrow.gameObject.SetActive(true);
            move.speed = possessionSpeed;
            //rb2d.simulated = false;
            //rb2d.velocity = Vector2.zero;
            //rb2d.angularVelocity = 0f;
            RotateShooterArrow();
        }
        else
        {
            shooterArrow.gameObject.SetActive(false);
            //rb2d.simulated = true;
            move.speed = moveSpeed;
        }
    }

    void RotateShooterArrow()
    {
        Transform football = transform.Find("SnitchBall");
        if (football != null)
        {
            ballDir = football.position - transform.position;
            float distance = ballDir.magnitude;
            ballDir = ballDir / distance;
        }
        float angle = Mathf.Atan2(ballDir.y, ballDir.x) * Mathf.Rad2Deg;
        angle -= 90.0f;
        shooterArrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
