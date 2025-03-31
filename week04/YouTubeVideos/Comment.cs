public class Comment
{
    // Propriedades
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    // Construtor
    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}