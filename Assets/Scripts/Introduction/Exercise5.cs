using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise5 : MonoBehaviour
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
      public float gaus; // holds value that comes from Gaussian equation
      float newX, newY, newNegX, newNegY; // stores new probability for step() x and y values
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
        //To create a Gaussian distribution in Unity we can actually use Random.Range() on two separate Random.Ranges
        float num = Random.Range(Random.Range(-10, 10), Random.Range(-10, 10));
        float sd = 1;
        float mean = 4;

        float gaus = sd*(num + mean);

        newX = Random.Range(-10f, 10f);
        newY = Random.Range(-10f, 10f);
        newNegX = Random.Range(-10f, 10f);
        newNegY = Random.Range(-10f, 10f);

      }

      public void step()
      {
        //Each frame choose a new Random number -10-10;
        //If the number is less than the the float take a step
        if (gaus < newX)
        {
          x++;
        }
        if (gaus < newNegX)
        {
          x--;
        }
        if (gaus < newY)
        {
          y++;
        }
        if (gaus < newNegY)
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
