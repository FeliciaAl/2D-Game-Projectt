using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playJump : MonoBehaviour
{
    public Animator jumpAnim;
    float animSpeed = 0.5f;
    int frameNum;

    AnimatorClipInfo[] m_currentClipInfo;
	// Use this for initialization
	void Start ()
    {
        jumpAnim = GetComponent<Animator>();
        jumpAnim.Play("jumpAnim");
        jumpAnim.speed = animSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
