using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
	public LetterContainer LetterContainer { get => _letterContainer; private set => _letterContainer = value; }

	[SerializeField] private LetterContainer _letterContainer;

	public void UpdateGold(int gold)
	{
		LetterContainer.SetText(gold.ToString());
	}
}
