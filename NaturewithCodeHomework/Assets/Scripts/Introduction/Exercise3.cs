using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise3 : MonoBehaviour
{

    // We need to instantiate the Walker PrefAB
    public GameObject WalkerPrefab;
    //And create a variable to track it
    private GameObject walkerGO;
    //And then we need to be able to access the walker Component on our walkerGO (Walker Game Object)
    private walker walker;


    // Start is called before the first frame update
    void Start()
    {
        GameObject walkerGameObject = new GameObject();
        walker = walkerGameObject.AddComponent<walker>();
    }

    // Update is called once per frame
    void Update()
    {
        //Have the walker choose a direction
        walker.step();
        //Instantiate the sphere in the last previous location to "draw" the path
        walker.draw();
    }


}


public class walker : MonoBehaviour
{

    public int x;
    public int y;
    float num;
    GameObject walkerGO;

    // Start is called before the first frame update
    void Start()
    {

    walkerGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    Destroy(walkerGO.GetComponent<SphereCollider>());

        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
      num = Random.Range(0f, 1f);
    }

    public void step()
    {
                //Each frame choose a new Random number 0-1;
                //If the number is less than the the float take a step
                if (num < 0.4F)
            {
                    x++;
                }
                else if (num < 0.6F)
            {
                    x--;
                }
                else if (num < .4F)
            {
                    y++;
                }
                else
                {
                    y--;
                }
                walkerGO.transform.position = new Vector3(x, y, 0F);
            }

    //Now let's draw the path of the Mover by creating spheres in its position in the most recent frame.
    public void draw()
    {
        //This creates a sphere GameObject
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(sphere.GetComponent<SphereCollider>());
        //This sets our ink "sphere game objects" at the position of the Walker GameObject (walkerGO) at the current frame
        //to draw the path
        sphere.transform.position = new Vector3(walkerGO.transform.position.x, walkerGO.transform.position.y, 0F);
    }

}
