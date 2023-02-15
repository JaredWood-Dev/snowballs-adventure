using System.Collections.Generic;
using UnityEngine;

public class classController : MonoBehaviour
{
    public Class[] classList = new Class[13];
    
    List<Class> possibleClasses = new List<Class>();

    public Class currentClass;



    // Start is called before the first frame update
    void Start()
    {
        //sets to the current class to a random class (not the last one (cleric))
        //currentClass = classList[Random.Range(0, 12)];    
        currentClass = classList[1];

        foreach (Class i in classList)
        {
            possibleClasses.Add(i);
        }

        Debug.Log(currentClass.className);
        Debug.Log(currentClass.primary.abilityName);
        Debug.Log(currentClass.secondary.abilityName);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
