using UnityEngine;
using System.Collections;

public class MapCollectableController : MonoBehaviour {

	public int id;

	public void OnTriggerEnter ()
	{
		// TODO "pick up" map

		if (id == 3) // last map to collect
		{
			UIAdapter.win();
		}
	}

}
