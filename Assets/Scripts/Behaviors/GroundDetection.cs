using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool IsTouchingGround { get; protected set; }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			IsTouchingGround = true;
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			IsTouchingGround = true;
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			IsTouchingGround = false;
	}
}
