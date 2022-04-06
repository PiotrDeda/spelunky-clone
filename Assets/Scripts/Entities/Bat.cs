using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
	protected enum ActionState
	{
		Asleep,
		Flying
	}

	[field: SerializeField] public float Speed { get; set; } = 2;
	[field: SerializeField] public float TriggerDistance { get; set; } = 4;

	protected ActionState CurrentState { get; set; } = ActionState.Asleep;
	protected Transform Target { get; set; }
	protected Collider2D TargetCollider { get; set; }
	protected Vector2 Direction { get; set; } = Vector2.zero;

	void Start()
	{
		Target = GameManager.Instance.Player.transform;
		TargetCollider = GameManager.Instance.Player.GetComponent<Collider2D>();
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		switch (CurrentState)
		{
			case ActionState.Asleep:
				Asleep();
				break;
			case ActionState.Flying:
				Flying();
				break;
		}
	}

	protected void Asleep()
	{
		Direction = Target.position - transform.position;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, TriggerDistance, LayerMask.GetMask("Player", "Ground"));
		//Debug.DrawRay(transform.position, Direction * TriggerDistance, Color.white);
		if (hit.collider == TargetCollider)
		{
			CurrentState = ActionState.Flying;
			Animator.SetBool("Flying", true);
		}
	}

	protected void Flying()
	{
		Direction = Target.position - transform.position;
		Rigidbody.velocity = Direction.normalized * Speed;

		// Auto-flip
		if ((Rigidbody.velocity.x < 0 && IsFlipped) || (Rigidbody.velocity.x > 0 && !IsFlipped))
			Flip();
	}
}
