using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Transform parent;
    public GameObject[] maps;
    public GameObject activeMap;
    public Animator activeAnimator;


    public float Timer;
    public float maxTimer;


    private void Start()
    {

        GameObject go = SetupNewMap();

        activeAnimator = go.GetComponent<Animator>();
        activeMap = go;

        Timer = UnityEngine.Random.Range(0, maxTimer);

        Timing.RunCoroutine(_ChangeMapCoroutine().CancelWith(this.gameObject));
    }

    private GameObject SetupNewMap()
    {
        int rnd = UnityEngine.Random.Range(0, maps.Length);

        return Instantiate(maps[rnd], Vector3.zero, Quaternion.identity, parent);       
    }

    private IEnumerator<float> _ChangeMapCoroutine()
    {
        while (true)
        {
            yield return Timing.WaitForSeconds(Timer);
            activeAnimator.SetTrigger("Disasamble");

            yield return Timing.WaitForSeconds(1.5f);
            Destroy(activeMap);

            GameObject go = SetupNewMap();
            activeAnimator = go.GetComponent<Animator>();
            activeMap = go;

            Timer = UnityEngine.Random.Range(0, maxTimer);
        }
    }
}

