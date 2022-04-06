using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSource : MonoBehaviour
{
	public enum CollisionType
	{
		PlayerPickupBox
	}

	[field: SerializeField] public CollisionType Type { get; protected set; } = CollisionType.PlayerPickupBox;
}
