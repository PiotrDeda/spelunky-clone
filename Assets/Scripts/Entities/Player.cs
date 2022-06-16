using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity
{
	public enum ActionState {
		Default,
		Crawling,
		Hanging,
		Climbing,
		Dead // Temp until bodies get added
	}

	[field: Header("Stats (Player)")]
	[field: SerializeField] public int MaxHealth { get; set; } = 99;

	[field: Header("References")]
	[field: SerializeField] public GroundDetection GroundDetection { get; protected set; }
	[field: SerializeField] public Animator WhipAnimator { get; protected set; }
	[field: SerializeField] public HealthContainer HealthContainer { get; protected set; }

	[field: Header("Events")]
	public UnityEvent<int> healthChanged;
	public UnityEvent<int> bombsChanged;
	public UnityEvent<int> ropesChanged;
	public UnityEvent<int> goldChanged;

	public int Bombs { get; protected set; } = 4;
	public int Ropes { get; protected set; } = 4;
	public int Gold { get; protected set; } = 0;

	protected ActionState CurrentState { get; set; } = ActionState.Default;
	protected bool Attacking { get; set; } = false;

	protected const float MovementSpeed = 5;
	protected const float JumpStrength = 10;

	/* 
	 * Unity lifecycle
	 */

	void Start()
	{
		healthChanged.Invoke(HealthContainer.Health);
		bombsChanged.Invoke(Bombs);
		ropesChanged.Invoke(Ropes);
		goldChanged.Invoke(Gold);
	}

	void Update()
	{
		switch (CurrentState)
		{
			case ActionState.Default:
				Default();
				break;
			case ActionState.Crawling:
				break;
			case ActionState.Hanging:
				break;
			case ActionState.Climbing:
				break;
			case ActionState.Dead:
				break;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();

		switch (CurrentState)
		{
			case ActionState.Default:
				FixedDefault();
				break;
			case ActionState.Crawling:
				break;
			case ActionState.Hanging:
				break;
			case ActionState.Climbing:
				break;
			case ActionState.Dead:
				break;
		}

		Animator.SetBool("Is Touching Ground", GroundDetection.IsTouchingGround);
	}

	/* 
	 * State methods
	 */

	protected void SwitchState(ActionState state)
	{
		CurrentState = state;
		Animator.SetInteger("State", (int)CurrentState);
	}

	protected void Default()
	{
		if (Input.GetKey(KeyCode.X) && !Attacking)
		{
			Animator.SetTrigger("Attack");
			WhipAnimator.SetTrigger("Attack");
			Attacking = true;
		}
	}

	protected void FixedDefault()
	{
		float movementInput = Input.GetAxisRaw("Horizontal");
		Rigidbody.velocity = new Vector2(movementInput * MovementSpeed, Rigidbody.velocity.y);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (IsFlipped) Flip();
			Animator.SetBool("Is Running", true);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			if (!IsFlipped) Flip();
			Animator.SetBool("Is Running", true);
		}
		else
		{
			Animator.SetBool("Is Running", false);
		}

		// Auto-flip
		if ((Rigidbody.velocity.x < 0 && IsFlipped) || (Rigidbody.velocity.x > 0 && !IsFlipped))
			Flip();

		// Jump
		if (Input.GetKey(KeyCode.Z) && GroundDetection.IsTouchingGround)
		{
			Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, JumpStrength);
			Animator.SetTrigger("Jumped");
		}
	}

	/* 
	 * Health Handler
	 */

	public void TakeDamage()
	{
		if (HealthContainer.Health > MaxHealth)
			HealthContainer.Health = MaxHealth;
		healthChanged.Invoke(HealthContainer.Health);
	}

	public void Heal()
	{
		if (HealthContainer.Health > MaxHealth)
			HealthContainer.Health = MaxHealth;
		healthChanged.Invoke(HealthContainer.Health);
	}

	public void Die()
	{
		SwitchState(ActionState.Dead);
	}

	/* 
	 * Other functions
	 */

	public void AddBombs(int amount)
	{
		Bombs += amount;
		if (Bombs > 99)
			Bombs = 99;
		bombsChanged.Invoke(Bombs);
	}

	public void RemoveBombs(int amount)
	{
		Bombs -= amount;
		if (Bombs > 99)
			Bombs = 99;
		bombsChanged.Invoke(Bombs);
	}

	public void AddRopes(int amount)
	{
		Ropes += amount;
		if (Ropes > 99)
			Ropes = 99;
		ropesChanged.Invoke(Ropes);
	}

	public void RemoveRopes(int amount)
	{
		Ropes -= amount;
		if (Ropes > 99)
			Ropes = 99;
		ropesChanged.Invoke(Ropes);
	}

	public void AddGold(int amount)
	{
		Gold += amount;
		goldChanged.Invoke(Gold);
	}

	public void RemoveGold(int amount)
	{
		Gold -= amount;
		goldChanged.Invoke(Gold);
	}

	protected void AttackFinished() => Attacking = false;
}
