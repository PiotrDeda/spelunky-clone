using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
	[field: SerializeField] public SpriteRenderer EntitySpriteRenderer;

	[field: SerializeField] public int StartingHealth { get; set; } = 1;
	[field: SerializeField] public float Iframes { get; set; } = 1.0f;
	[field: SerializeField] public bool DestroyOnDeath { get; set; } = true;

	public int Health { get; set; } = 1;
	public bool IsIFrameInvisible { get; protected set; } = false;

	public UnityEvent<int> TookDamageAmount;
	public UnityEvent<Transform> TookDamageSource;
	public UnityEvent<int> Healed;
	public UnityEvent Died;

	void Awake()
	{
		Health = StartingHealth;
	}

	public void TakeDamage(int damageAmount, Transform sourceTransform)
	{
		if (IsIFrameInvisible)
			return;
		Health -= damageAmount;
		if (Health < 0)
			Health = 0;
		TookDamageAmount.Invoke(damageAmount);
		TookDamageSource.Invoke(sourceTransform);
		if (Health == 0)
			Die();
		IsIFrameInvisible = true;
		StartCoroutine(DoIFrames());
	}

	public void TakeDamage(DamageSource source) => TakeDamage(source.Damage, source.SourceTransform);
	public void TakeDamage(int damageAmount) => TakeDamage(damageAmount, null);

	public void Heal(int healAmount)
	{
		Health += healAmount;
		if (Health < 0)
			Health = 0;
		Healed.Invoke(healAmount);
		if (Health == 0)
			Die();
	}

	public void Die()
	{
		Died.Invoke();
		if (DestroyOnDeath)
			Destroy(gameObject);
	}

	protected IEnumerator DoIFrames()
	{
		float iFrameDuration = Iframes / 10;
		for (int i = 0; i < 10; i++)
		{
			EntitySpriteRenderer.enabled = !EntitySpriteRenderer.enabled;
			yield return new WaitForSeconds(iFrameDuration);
		}
		EntitySpriteRenderer.enabled = true;
		IsIFrameInvisible = false;
	}
}
