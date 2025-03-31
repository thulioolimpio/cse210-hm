using System.Collections.Generic;

public class Video
{
    // Propriedades
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments = new List<Comment>();

    // Construtor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Método para adicionar comentário
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Método para obter número de comentários
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Método para obter todos os comentários
    public List<Comment> GetAllComments()
    {
        return new List<Comment>(_comments);
    }
}