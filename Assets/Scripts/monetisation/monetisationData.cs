using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonetisationDataHolder",menuName = "MonetisationData")]
public class monetisationData : ScriptableObject
{    
    public int ammountOfTimesSinceAds=0;
    public int WhenToShowAds=1;
    public bool hasPurchasedContent=false;
}
