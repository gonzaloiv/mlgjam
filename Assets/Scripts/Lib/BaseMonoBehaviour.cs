using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour {

	#region Public Behaviour

	public virtual void Init () {
		gameObject.SetActive(true);
		gameObject.SetActive(false);
	}

	public virtual void Show () {
		gameObject.SetActive(true);
	}

	public virtual void Hide () {
		gameObject.SetActive(false);
	}

	#endregion

}