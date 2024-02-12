using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Camera camera;

    public float damage = 1.0f;

    void Start()
    {
        camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                //StartCoroutine(SphereIndicator(hit.point));
                // Debug.Log(hit.transform.name); To tell out name of what it shooting at.

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    //Debug.Log("HIT");
                    target.TakeDamage(damage);
                }

                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }

            }
        }
    }
        private IEnumerator SphereIndicator(Vector3 position)
        {


            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = position;

            yield return new WaitForSeconds(1);

            Destroy(sphere);
        }

        private void OnGUI()
        {
            int size = 12;
            float posX = camera.pixelWidth / 2 - size / 4;
            float posY = camera.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
    }

 
