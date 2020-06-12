using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bomberman
{
	public class Explosion001Script : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
		}

		/// <summary>
		/// パーティクルの再生終了時のCallback
		/// </summary>
		private void OnParticleSystemStopped()
		{
			// パーティクル終了後に消滅する
			Destroy(this.gameObject);
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log(string.Format("Explosion001Script OnTriggerEnter tag={0}", other.tag));
		}
	}
}