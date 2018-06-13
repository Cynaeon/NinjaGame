using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public float angle;

    public ParticleSystem ps;
    public Collider coll;

    internal bool striking;
    private bool backwardSwing;
    private float currentAngle;
    private float timeUntilReset = 0.5f;

    public void Swing(float speed)
    {
        striking = true;
        StartCoroutine(CoSwing(speed));
    }

    private IEnumerator CoSwing(float speed)
    {
        coll.enabled = true;
        if (backwardSwing)
        {
            while (currentAngle > 0)
            {
                ps.Emit(5);
                transform.Rotate(0, -speed, 0);
                currentAngle -= speed;
                yield return null;
            }
            currentAngle = 0;
            backwardSwing = false;
        }
        else
        {
            while (currentAngle < angle)
            {
                ps.Emit(5);
                transform.Rotate(0, speed, 0);
                currentAngle += speed;
                yield return null;
            }
            currentAngle = angle;
            backwardSwing = true;
        }
        coll.enabled = false;
        striking = false;
    }
}

