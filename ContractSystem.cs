using System.Collections.Generic;
using UnityEngine;

public class ContractSystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerContract
    {
        public string playerName;

        public int salary;
        public int contractYears;

        public bool activeContract;
    }


    public List<PlayerContract> contracts = new List<PlayerContract>();


    void Start()
    {
        CreateContracts();
    }


    void CreateContracts()
    {
        contracts.Add(new PlayerContract
        {
            playerName = "Craque Principal",
            salary = 50000,
            contractYears = 3,
            activeContract = true
        });

        contracts.Add(new PlayerContract
        {
            playerName = "Jovem Talento",
            salary = 10000,
            contractYears = 5,
            activeContract = true
        });
    }


    public void RenewContract(int index, int years)
    {
        if (index < 0 || index >= contracts.Count)
            return;

        contracts[index].contractYears += years;

        Debug.Log(
            "Contrato renovado: " +
            contracts[index].playerName
        );
    }


    public void ReduceContractYear()
    {
        foreach (PlayerContract contract in contracts)
        {
            if (contract.activeContract)
            {
                contract.contractYears--;

                if (contract.contractYears <= 0)
                {
                    contract.activeContract = false;

                    Debug.Log(
                        contract.playerName +
                        " ficou sem contrato."
                    );
                }
            }
        }
    }


    public void ReleasePlayer(int index)
    {
        if (index < 0 || index >= contracts.Count)
            return;

        contracts[index].activeContract = false;

        Debug.Log(
            contracts[index].playerName +
            " foi liberado do clube."
        );
    }
}
