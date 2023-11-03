using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            if (Vector2.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
            {
                float timeProgression = (Time.time - activeTween.StartTime) / activeTween.Duration;
                Vector2 currentPos = Vector2.Lerp(activeTween.StartPos, activeTween.EndPos, timeProgression);
                activeTween.Target.position = currentPos;
            }

            else
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
        }



    }

    public bool AddTween(Transform targetObject, Vector2 startPos, Vector2 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween (targetObject, startPos, endPos, Time.time, duration);
            return true;
        }
        return false;
    }
}
