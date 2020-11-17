using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Zombies;
    public bool isRising = false;
    public bool isFalling = false;
    public int activeZombieIndex = 0;
    Vector2 startPosition;
    public int riseSpeed = 1;
    void Start()
    {
        pickNewZombies();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {

           // Zombies[activeZombieIndex].transform.Translate(Vector2.up*Time.deltaTime*riseSpeed);

            if(Zombies[activeZombieIndex].transform.position.y - startPosition.y >= 1.7f)
            {
                isRising = false;
                isFalling = true;
            }
            else
            {
                Zombies[activeZombieIndex].transform.Translate(Vector2.up * Time.deltaTime * riseSpeed);
            }

        }else if (isFalling)
        {

            if(Zombies[activeZombieIndex].transform.position.y - startPosition.y <= 0f)
            {
                isFalling = false;
                isRising = false;
            }
            else
            {
                Zombies[activeZombieIndex].transform.Translate(Vector2.down * Time.deltaTime * riseSpeed);
            }

        }
        else
        {
            Zombies[activeZombieIndex].transform.position = startPosition;
            pickNewZombies();
        }
    }

    private void pickNewZombies()
    {
        isRising = true;
        isFalling = false;
        activeZombieIndex = UnityEngine.Random.Range(0,Zombies.Length);
        //GameObject activeZombies = Zombies[activeZombieIndex];
        //Transform activeTransform = activeZombies.transform;
        //Vector2 startPosition = activeTransform.position;
        startPosition = Zombies[activeZombieIndex].transform.position;
    }
}
