using Data.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Containers/User W-NFTs")]
public class UserWNFTsContainer : ScriptableObject
{
    public List<WNFT> wNFTs;
}
