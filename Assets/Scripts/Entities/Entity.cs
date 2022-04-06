using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public Rigidbody2D Rigidbody { get; protected set; }
	public Collider2D Collider { get; protected set; }
	public SpriteRenderer SpriteRenderer { get; protected set; }
	public Animator Animator { get; protected set; }

	public int Damage { get; protected set; } = 1;
	public bool IsFlipped { get; protected set; } = false;

	protected const float FallMultiplier = 2.5f;
	protected const float LowJumpMultiplier = 2;

	protected virtual void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
		Collider = GetComponent<Collider2D>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		Animator = GetComponent<Animator>();
	}

	protected virtual void FixedUpdate()
	{
		ApplyFallMultiplier();
	}

	public void Flip()
	{
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		IsFlipped = !IsFlipped;
	}

	protected void ApplyFallMultiplier()
	{
		if (Rigidbody.velocity.y < 0)
			Rigidbody.velocity += (FallMultiplier - 1) * Time.deltaTime * Physics2D.gravity * Vector2.up;
		else if (Rigidbody.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
			Rigidbody.velocity += (LowJumpMultiplier - 1) * Time.deltaTime * Physics2D.gravity * Vector2.up;

	}
}
