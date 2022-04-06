using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageHitbox : MonoBehaviour
{
	[field: SerializeField] public List<DamageSource.DamageType> DamageSources { get; set; } = new() { DamageSource.DamageType.Player };

	public UnityEvent<DamageSource> damageSourceColliding;
	public UnityEvent<int> damageSourceCollidingDamageAmount;

	void OnTriggerStay2D(Collider2D collision)
	{
		DamageSource damageSource = collision.gameObject.GetComponent<DamageSource>();
		if (damageSource && DamageSources.Contains(damageSource.Type))
		{
			damageSourceColliding.Invoke(damageSource);
			damageSourceCollidingDamageAmount.Invoke(damageSource.Damage);
			damageSource.damageDealt.Invoke();
		}
	}
}
