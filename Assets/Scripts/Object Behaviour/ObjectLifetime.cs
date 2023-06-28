using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Object apapun yang ditempel script ini hanya punya beberapa waktu di dalam hierarchy, ketika waktunya habis, maka ia akan hilang

public class ObjectLifetime : MonoBehaviour
{
    public float lifeTime;

    public float blinkningDelay;

    public UnityEvent OnTimerReachedZero;
    
    private float timer;

    void Start()
    {
        timer = lifeTime;

        StartCoroutine(ObjectTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
           OnTimerReachedZero?.Invoke(); // object akan hancur setelah waktu lifetime yang ditentukan di inspector unity
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator ObjectTimer()
    {
        Color defaultColor = GetComponent<SpriteRenderer>().color;
        Color blinkColor = defaultColor;
        blinkColor.a = 0.5f;

        yield return new WaitForSeconds(lifeTime * 0.7f);

        while (timer > 0)
        {
            GetComponent<SpriteRenderer>().color = blinkColor;
            yield return new WaitForSeconds(blinkningDelay);
            GetComponent<SpriteRenderer>().color = defaultColor;
            yield return new WaitForSeconds(blinkningDelay);
        }
    }
}
