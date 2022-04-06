using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
	public SpriteAtlas FontAtlas { get => _fontAtlas; private set => _fontAtlas = value; }

	[SerializeField] private SpriteAtlas _fontAtlas;

	public void SetCharacter(char character)
	{
		Sprite letterSprite = _fontAtlas.GetSprite(character.ToString().ToUpper());
		if (letterSprite)
			GetComponent<Image>().sprite = letterSprite;
		else
			GetComponent<Image>().sprite = _fontAtlas.GetSprite("Space");
	}
}
