using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHitbox : MonoBehaviour
{
	[field: SerializeField] public List<CollisionSource.CollisionType> CollisionSources { get; set; } = new() { CollisionSource.CollisionType.PlayerPickupBox };

	public UnityEvent<CollisionSource> collisionSourceCollided;

	void OnTriggerEnter2D(Collider2D collision)
	{
		CollisionSource collisionSource = collision.gameObject.GetComponent<CollisionSource>();
		if (collisionSource && CollisionSources.Contains(collisionSource.Type))
			collisionSourceCollided.Invoke(collisionSource);
	}
}
