using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMode))]
public class BallGrabber : MonoBehaviour
{
    PlayerMode playerMode;
    Transform grabee;
    Rigidbody2D rb2d;
    [SerializeField] KeyCode fireButton = KeyCode.Space;
    float buttonTimer = 0f;
    [SerializeField] float buttonTimeout = 0.2f;

    int frameCount;
    public int shootDelay = 3;

    [SerializeField] float basePower = 3.0f;
    [SerializeField] float additionalPower = 5.0f;
    [SerializeField] float powerIncrement = 50.0f;

    [SerializeField] Text powerText;

    private void Start()
    {
        playerMode = GetComponent<PlayerMode>();
    }

    private void Update()
    {
        if (frameCount > 0) { frameCount--; }
        powerText.text = Mathf.FloorToInt(powerIncrement * buttonTimer).ToString();
    }

    public void Grab(Transform t)
    {
        if (frameCount == 0)
        {
            grabee = t;
            grabee.SetParent(this.transform);
            rb2d = grabee.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.simulated = false;
                rb2d.velocity = Vector2.zero;
                rb2d.angularVelocity = 0f;
            }

            playerMode.SwitchMode(true);
        }
    }

    public void Release()
    {
        if (grabee != null && rb2d != null)
        {
            if (Input.GetKey(fireButton) && buttonTimer < buttonTimeout)
            {
                buttonTimer += Time.deltaTime;
            }
            else if (buttonTimer > buttonTimeout)
            {
                buttonTimer = buttonTimeout;
                ReleaseNow();
            }
            else
            {
                ReleaseNow();
            }
        }       
    }

    public void ReleaseNow()
    {

        if (grabee != null)
        {
            float shotPower = basePower + (additionalPower * (buttonTimer / buttonTimeout));
            rb2d.simulated = true;

            grabee.SetParent(this.transform.parent);

            playerMode.Shoot(grabee, rb2d, shotPower);

            playerMode.SwitchMode(false);

            frameCount = shootDelay;

            grabee = null;

            buttonTimer = 0f;
        }
    }

}
