using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
	[field: SerializeField] public Rigidbody2D EntityRigidbody { get; protected set; }

	public void Push()
	{
		EntityRigidbody.velocity = new Vector2(EntityRigidbody.velocity.x, 12.5f);
	}

	public void Push(Transform source)
	{
		EntityRigidbody.velocity = new Vector2(5.0f * (transform.position.x > source.position.x ? 1 : -1), 3.0f);
	}

	public void Push(DamageSource damageSource) => Push(damageSource.SourceTransform);
}
