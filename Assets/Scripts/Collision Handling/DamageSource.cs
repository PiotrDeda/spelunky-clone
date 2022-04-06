using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageSource : MonoBehaviour
{
	public enum DamageType
	{
		Player,
		Enemy,
		PlayerStomp
	}

	public UnityEvent damageDealt;

	[field: SerializeField] public DamageType Type { get; protected set; } = DamageType.Enemy;
	[field: SerializeField] public Transform SourceTransform { get; protected set; } = null;
	[field: SerializeField] public int Damage { get; protected set; } = 1;
}
