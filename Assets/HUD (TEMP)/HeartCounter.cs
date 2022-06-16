using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCounter : MonoBehaviour
{
	[field: SerializeField] public LetterContainer LetterContainer { get; protected set; }

	public void UpdateHealth(int health)
	{
		LetterContainer.SetText(health.ToString());
	}
}