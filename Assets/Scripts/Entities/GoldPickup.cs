using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldPickup : MonoBehaviour
{
	[field: SerializeField] public int BaseGold { get; set; }

	public UnityEvent<int> goldPickedUp;

	void Start()
	{
		goldPickedUp.AddListener(GameManager.Instance.Player.GetComponent<Player>().AddGold);
	}

	public void PickedUp()
	{
		goldPickedUp.Invoke(GetFloorGoldValue());
		Destroy(gameObject);
	}

	public int GetFloorGoldValue() => BaseGold + BaseGold * (GameManager.Instance.Area - 1) / 4;
}
