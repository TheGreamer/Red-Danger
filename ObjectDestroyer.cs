using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject explosion;

    private void OnMouseDown()
    {
        if (!MenuManagement.isPaused && !Trigger.levelFailed && !ShapeNumbers.levelCompleted && !ShapeNumbers.isLoadingCircleActive && !Rating.isShown)
        {
            List<string> objectTags = new List<string>
            {
                "Red Block",
                "Red Shape",
                "Red Shape Left",
                "Red Shape Right",
                "Red Shape Up",
                "Blue Block",
                "Blue Shape",
                "Blue Shape Left",
                "Blue Shape Right",
                "Blue Shape Up"
            };

            for (int i = 0; i < objectTags.Count; i++)
            {
                if (gameObject.CompareTag(objectTags[i]))
                {
                    GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);
                    if (SoundToggle.isToggled)
                    {
                        GetComponent<AudioSource>().Play();
                    }
                    Destroy(gameObject, 0.145f);
                    Destroy(explosionObject, 0.250f);
                }
            }

            Destroy(GameObject.Find("Advertisement Button"));
        }
    }
}