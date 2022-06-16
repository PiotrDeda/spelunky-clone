using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
	[field: SerializeField] public LetterContainer LetterContainer { get; protected set; }

	public void UpdateGold(int gold)
	{
		LetterContainer.SetText(gold.ToString());
	}
}