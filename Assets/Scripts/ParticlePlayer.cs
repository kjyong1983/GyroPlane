using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour, IEffectPlayer {

	public List<GameObject> particles;
    public void PlayEffect(int index)
    {
        var position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
		var particleInstance = Instantiate(particles[index], position, Quaternion.identity);
		particleInstance.GetComponent<ParticleSystem>().Play(true);
		Destroy(particleInstance, 3f);
	}

}
