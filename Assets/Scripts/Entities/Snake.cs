using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{
	protected enum ActionState
	{
		Idle,
		Walking
	}

	[field: SerializeField] public float Speed { get; set; } = 1.375f;

	protected ActionState CurrentState { get; set; } = ActionState.Idle;
	protected const float RayGroundOffest = 0.4f;
	protected const float RaySize = 0.6f;

	void Update()
	{
		switch (CurrentState)
		{
			case ActionState.Idle:
				CurrentState = ActionState.Walking;
				Animator.SetBool("Walking", true);
				break;
			case ActionState.Walking:
				break;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		switch (CurrentState)
		{
			case ActionState.Idle:
				break;
			case ActionState.Walking:
				Walking();
				break;
		}
	}

	protected void Walking()
	{
		Rigidbody.velocity = new Vector2(IsFlipped ? Speed : -Speed, Rigidbody.velocity.y);

		Vector3 rayGroundSource = IsFlipped ? (transform.position + Vector3.right * RayGroundOffest) : (transform.position + Vector3.left * RayGroundOffest);
		Vector2 rayFrontDirection = IsFlipped ? Vector2.right : Vector2.left;

		RaycastHit2D hitGround = Physics2D.Raycast(rayGroundSource, Vector2.down, RaySize, LayerMask.GetMask("Ground"));
		RaycastHit2D hitFront = Physics2D.Raycast(transform.position, rayFrontDirection, RaySize, LayerMask.GetMask("Ground"));

		Debug.DrawRay(rayGroundSource, Vector2.down * RaySize, Color.white);
		Debug.DrawRay(transform.position, rayFrontDirection * RaySize, Color.white);

		if (Mathf.Abs(Rigidbody.velocity.y) <= 0.05 && !hitGround.collider || hitFront.collider)
			Flip();
	}
}
