using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player _player =  other.GetComponent<Player>();
            _player.incrementCoin();
            Destroy(this.gameObject);
        }
    }
}
