using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlowWhenShot : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float slowFactor = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SlowByPercent()
    {
        Debug.Log("I'm HIT!");
        rb2d.velocity = rb2d.velocity * (slowFactor / 100);
    }

    public void SlowByImpulse()
    {
        Debug.Log("I'm HIT!");
        rb2d.AddForce(-transform.up * slowFactor, ForceMode2D.Force);
    }

}
