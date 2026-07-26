using UnityEngine;
using System.Collections.Generic;

public class OnlineManager : MonoBehaviour
{
    public static OnlineManager Instance;

    public string playerName = "Jogador";

    public bool connected = false;

    public List<string> playersOnline = new List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Connect()
    {
        connected = true;

        Debug.Log("Conectado ao servidor!");

        AddPlayer(playerName);
    }

    public void Disconnect()
    {
        connected = false;

        playersOnline.Clear();

        Debug.Log("Desconectado.");
    }

    public void AddPlayer(string name)
    {
        if (!playersOnline.Contains(name))
        {
            playersOnline.Add(name);

            Debug.Log(name + " entrou na partida.");
        }
    }

    public void RemovePlayer(string name)
    {
        if (playersOnline.Contains(name))
        {
            playersOnline.Remove(name);

            Debug.Log(name + " saiu da partida.");
        }
    }

    public void CreateRoom()
    {
        Debug.Log("Sala criada!");
    }

    public void JoinRoom(string roomName)
    {
        Debug.Log("Entrando na sala: " + roomName);
    }

    public void StartOnlineMatch()
    {
        Debug.Log("Partida online iniciada!");
    }
}
