using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string keyUp;
    public string keyDown;
    public string keyLeft;
    public string keyRight;

    public string keyRunA;
    public string keyB;
    public string keyC;
    public string keyD;

    [Header("===== Output signals =====")]
    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    // 1.pressing signal
    public bool run;
    // 2.trigger once signal
    // 3.double trigger

    [Header("===== Others =====")]
    public bool inputEnabled = true;

    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;

    // Start is called before the first frame update
    void Start()
    {
        keyRunA = "j";
    }

    // Update is called once per frame
    void Update()
    {
        targetDup = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);

        if (inputEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        // TODO
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);
        Dmag = Mathf.Sqrt((Dup * Dup) + (Dright * Dright));
        Dvec = Dright * transform.right + Dup * transform.forward;

        run = Input.GetKey(keyRunA);
    }
}
