using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise4 : MonoBehaviour
{


  // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {

          //To create a Gaussian distribution in Unity we can actually use Random.Range() on two separate Random.Ranges
          float numx = Random.Range(Random.Range(-10, 10), Random.Range(-10, 10));
          float numy = Random.Range(Random.Range(-10, 10), Random.Range(-10, 10));
          float sdx = 1;
          float sdy = 1;
          float meanx = 4;
          float meany = 8;

          float x = sdx *(numx + meanx);
          float y = sdy *(numy + meany);

          //This creates a sphere GameObject
          GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
          sphere.GetComponent<MeshRenderer>().material.color = new Color (Random.Range (0F, 255F), Random.Range (0F, 255F), Random.Range (0F, 255F), Random.Range (0F, 255F));
          Destroy(sphere.GetComponent<SphereCollider>());

          //This sets our ink "sphere game objects" at the position of the Walker GameObject (walkerGO) at the current frame
          //to draw the path
          sphere.transform.position = new Vector3(x, y, 0F);

      }
}
