using Data.Objects;
using MoralisUnity;
using MoralisUnity.Web3Api.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WNFTsGetter : MonoBehaviour
{
    private const string W_NFT_CONTRACT_ADDRESS = "0x86702dd104c328578cdc83ce69b306accf0b57ef";

    [SerializeField] private UserWNFTsContainer container;

    private IEnumerator Start()
    {
#if UNITY_EDITOR
        //Wait for moralis to connect to your DAPP
        while(Moralis.State != MoralisState.Initialized)
            yield return null;
        var healthHeroWallet = "0x9562c319aedfede63b1796de90ca185ad2ffbc6d";
        GetUserWNFTs(healthHeroWallet);
#endif
    }
    public async void GetUserWNFTs()
    {
        //Moralis needs to be connected to your DAPP
        if (Moralis.State != MoralisState.Initialized)
        {
            Debug.LogError($"Moralis is not initalized");
            return;
        }
        var user = await Moralis.GetUserAsync();
        container.wNFTs = new List<WNFT>();
        if (user != null)
        {
            NftOwnerCollection resp = await Moralis.Web3Api.Account.GetNFTsForContract(user.ethAddress, W_NFT_CONTRACT_ADDRESS, ChainList.polygon);
            foreach (var card in resp.Result)
            {
                //Some cards do not have metadata
                if (!string.IsNullOrEmpty(card.Metadata))
                {
                    var wNft = JsonConvert.DeserializeObject<WNFT>(card.Metadata);
                    container.wNFTs.Add(wNft);
                }
            }
        }
    }
    public async void GetUserWNFTs(string userAddress)
    {
        //Moralis needs to be connected to your DAPP
        if (Moralis.State != MoralisState.Initialized)
        {
            Debug.LogError($"Moralis is not initalized");
            return;
        }
        container.wNFTs = new List<WNFT>();
        NftOwnerCollection resp = await Moralis.Web3Api.Account.GetNFTsForContract(userAddress, W_NFT_CONTRACT_ADDRESS, ChainList.polygon);
        foreach (var card in resp.Result)
        {
            //Some cards do not have metadata
            if (!string.IsNullOrEmpty(card.Metadata))
            {
                var wNft = JsonConvert.DeserializeObject<WNFT>(card.Metadata);
                container.wNFTs.Add(wNft);
            }
        }
    }
}
