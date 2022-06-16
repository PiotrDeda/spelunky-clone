using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
	[field: SerializeField] public Letter[] Letters { get; protected set; }

	public void SetText(string text)
	{
		text = text.Length < Letters.Length ? text.PadRight(Letters.Length) : text[..(Letters.Length - 1)] + ".";
		for (int i = 0; i < Letters.Length; i++)
		{
			Letters[i].SetCharacter(text[i]);
		}
	}
}