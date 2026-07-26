using UnityEngine;
using System.Collections.Generic;

public class CommentarySystem : MonoBehaviour
{
    public AudioSource commentaryAudio;

    public List<AudioClip> goalComments = new List<AudioClip>();
    public List<AudioClip> saveComments = new List<AudioClip>();
    public List<AudioClip> shotComments = new List<AudioClip>();
    public List<AudioClip> crowdComments = new List<AudioClip>();

    public void GoalCommentary()
    {
        PlayRandomComment(goalComments);

        Debug.Log("Narração: GOOOOOOL!");
    }

    public void SaveCommentary()
    {
        PlayRandomComment(saveComments);

        Debug.Log("Narração: Que defesa incrível!");
    }

    public void ShotCommentary()
    {
        PlayRandomComment(shotComments);

        Debug.Log("Narração: Finalização perigosa!");
    }

    public void CrowdReaction()
    {
        PlayRandomComment(crowdComments);

        Debug.Log("Torcida fazendo barulho!");
    }

    void PlayRandomComment(List<AudioClip> comments)
    {
        if (commentaryAudio == null || comments.Count == 0)
            return;

        int index = Random.Range(0, comments.Count);

        commentaryAudio.PlayOneShot(comments[index]);
    }

    public void MatchStart()
    {
        Debug.Log("Narração: A bola vai rolar!");
    }

    public void MatchEnd()
    {
        Debug.Log("Narração: Fim de jogo!");
    }
}
