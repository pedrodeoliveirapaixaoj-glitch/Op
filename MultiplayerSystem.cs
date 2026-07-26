using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSystem : MonoBehaviour
{
    [System.Serializable]
    public class Room
    {
        public string roomName;
        public int players;
        public int maxPlayers = 2;
        public bool started;
    }


    public List<Room> rooms = new List<Room>();

    public string playerName;


    public void CreateRoom(string name)
    {
        Room newRoom = new Room();

        newRoom.roomName = name;
        newRoom.players = 1;
        newRoom.started = false;

        rooms.Add(newRoom);

        Debug.Log(
            "Sala criada: " + name
        );
    }


    public void JoinRoom(int index)
    {
        if (index < 0 || index >= rooms.Count)
            return;


        Room room = rooms[index];


        if (room.players < room.maxPlayers)
        {
            room.players++;

            Debug.Log(
                "Entrou na sala: " +
                room.roomName
            );


            if (room.players == room.maxPlayers)
            {
                StartMatch(room);
            }
        }
        else
        {
            Debug.Log("Sala cheia!");
        }
    }


    void StartMatch(Room room)
    {
        room.started = true;

        Debug.Log(
            "Partida online iniciada!"
        );
    }


    public void LeaveRoom(int index)
    {
        if (index < 0 || index >= rooms.Count)
            return;


        rooms[index].players--;

        Debug.Log(
            "Jogador saiu da sala."
        );
    }


    public void SendMatchResult(
        string winner,
        int goals
    )
    {
        Debug.Log(
            "Vencedor: " +
            winner +
            " | Gols: " +
            goals
        );
    }
}
