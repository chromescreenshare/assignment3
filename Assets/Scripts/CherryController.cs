using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject carrot;
    private GameObject carrotTracker;
    private Tweener cherryTweener;
    private float delay;
    private float counter;

    private float xRandom;
    private float yRandom;

    private int randomiser;
    private float carrotRandomiser;
    private int secondaryRandomiser;

    // Start is called before the first frame update
    void Start()
    {
        cherryTweener = GetComponent<Tweener>();
        delay = 10.0f;
        counter = 0;

        randomiser = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomiser == 1)
        {
            carrotRandomiser = Random.Range(-5f, 35f);
        }

        else if (randomiser == 2)
        {
            carrotRandomiser = Random.Range(0f, 35f);
        }

        counter += Time.deltaTime;
        if (counter >= delay)
        {
            if (carrotTracker != null)
            {
                Destroy(carrotTracker);
            }

            secondaryRandomiser = Random.Range(1, 3);
            if (randomiser == 1)
            {
                if (secondaryRandomiser == 1)
                {
                    carrotTracker = Instantiate(carrot, new Vector3(carrotRandomiser, 30f, 10f), Quaternion.identity);
                    counter = 0;
                    Debug.Log(secondaryRandomiser);
                    cherryTweener.AddTween(carrotTracker.transform, carrotTracker.transform.position, new Vector2(carrotRandomiser + 2*(13.5f-carrotRandomiser), 0f), delay);
                }

                if (secondaryRandomiser == 2)
                {
                    carrotTracker = Instantiate(carrot, new Vector3(carrotRandomiser, 0f, 10f), Quaternion.identity);
                    counter = 0;
                    Debug.Log(secondaryRandomiser);
                    cherryTweener.AddTween(carrotTracker.transform, carrotTracker.transform.position, new Vector2(carrotRandomiser + 2 * (13.5f - carrotRandomiser), 30f), delay);
                }
            }

            if (randomiser == 2)
            {
                if (secondaryRandomiser == 1)
                {
                    carrotTracker = Instantiate(carrot, new Vector3(35f, carrotRandomiser, 10f), Quaternion.identity);
                    counter = 0;
                    Debug.Log(secondaryRandomiser);
                    cherryTweener.AddTween(carrotTracker.transform, carrotTracker.transform.position, new Vector2(-5f, 30f - carrotRandomiser), delay);
                }

                if (secondaryRandomiser == 2)
                {
                    carrotTracker = Instantiate(carrot, new Vector3(-5f, carrotRandomiser, 10f), Quaternion.identity);
                    counter = 0;
                    Debug.Log(secondaryRandomiser);
                    cherryTweener.AddTween(carrotTracker.transform, carrotTracker.transform.position, new Vector2(35f, 30f - carrotRandomiser), delay);
                }
            }

        }
        randomiser = Random.Range(1, 3);


    }
}
