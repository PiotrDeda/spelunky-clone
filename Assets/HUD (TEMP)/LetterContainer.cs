using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
	public Letter[] Letters { get => _letters; private set => _letters = value; }

	[SerializeField] private Letter[] _letters;

	public void SetText(string text)
	{
		if (text.Length < _letters.Length)
		{
			text = text.PadRight(_letters.Length);
		}
		else
		{
			text = text.Substring(text.Length - _letters.Length);
		}
		for (int i = 0; i < Letters.Length; i++)
		{
			Letters[i].SetCharacter(text[i]);
		}
	}
}