using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0, 2f));

        GetComponent<Animation>().Play();
    }
}
