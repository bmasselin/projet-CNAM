/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class AISense : MonoBehaviour
{
    public struct Stimulus
    {
        Vector3 position;
    }

    public Transform SenseTransform;

    public float updateInterval = 0.3f;
    private float updateTime = 0.0f;

    public bool ShowDebug = true;
    protected List<Transform> trackedObjects = new List<Transform>();
    protected List<Transform> sensedObjects = new List<Transform>();

    private Stimulus stimulus;

    //On appelle de manière recurrente la gestion du sens.
    //Si perception, on lance un event
    void Update()
    {
        updateTime += Time.deltaTime;
        if (updateTime > updateInterval)
        {
            resetSense();

            foreach (Transform t in trackedObjects)
            {
                stimulus = default(Stimulus);
                if (doSense(t, ref stimulus))
                {
                    if (!sensedObjects.Contains(t))
                    {
                        sensedObjects.Add(t);
                        senseEvent(stimulus);
                    }
                }
                else
                {
                    sensedObjects.Remove(t);
                }
            }
            updateTime = 0;
        }
    }

    //A redefinir pour créer un nouveau sens
    //Détermine si on a percu quelquechose, et dans ce cas, en donne les paramètres
    protected abstract bool doSense(Transform obj, ref Stimulus sti);

    //A redéfinir pour savoir quand un objet a été détecté
    protected virtual senseEvent(Stimulus sti)
    {
    }   

    //Appelée juste avant de checker tous les objets
    //Peut etre redéfinie
    protected virtual void resetSense()
    {

    }

    //A appeler pour ajouter un objet à tracker
    public void AddObjectToTrack(Transform t)
    {
        trackedObjects.Add(t);
    }

    public void OnDrawGizmos()
    {
        if (!ShowDebug)
            return;

        Gizmos.color = Color.red;
        foreach (Transform t in sensedObjectsDebug)
        {
            Gizmos.DrawLine(SenseTransform.position, t.position);
        }
    }
}*/