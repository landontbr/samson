using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int wand;

    void Start()
    {
        wand = (int)this.transform.parent.GetComponent<SteamVR_TrackedController>().controllerIndex;
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("touched");

        rumbleController();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy");

            if (collision.relativeVelocity.magnitude > 0)
            {
                Debug.Log("damage");
            }
        }

        //audioSource.Play();
    }

    void rumbleController()
    {
            StartCoroutine(LongVibration(0.1f, 3999));
    }

    IEnumerator LongVibration(float length, ushort strength)
    {
        for (float i = 0; i < length; i += Time.deltaTime)
        {
            SteamVR_Controller.Input(wand).TriggerHapticPulse(strength);
            yield return null;
        }
    }

}
