using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonetisationDataHolder",menuName = "MonetisationData")]
public class monetisationData : ScriptableObject
{
    int ammountOfTimesSinceAds=0;
    int WhenToShowAds=1;
    bool hasPurchasedContent=false;
}
