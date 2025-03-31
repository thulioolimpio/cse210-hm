using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criar lista de vídeos
        List<Video> videos = new List<Video>();

        // Criar e configurar vídeo 1
        Video video1 = new Video("Como Programar em C#", "João Dev", 600);
        video1.AddComment(new Comment("Maria", "Ótimo tutorial!"));
        video1.AddComment(new Comment("Pedro", "Muito útil para iniciantes."));
        video1.AddComment(new Comment("Ana", "Quando sai a parte 2?"));
        videos.Add(video1);

        // Criar e configurar vídeo 2
        Video video2 = new Video("Aprendendo ASP.NET Core", "Tech Solutions", 1200);
        video2.AddComment(new Comment("Carlos", "Excelente explicação!"));
        video2.AddComment(new Comment("Luiza", "Poderia fazer um sobre Blazor?"));
        video2.AddComment(new Comment("Fernando", "Muito bom, obrigado!"));
        video2.AddComment(new Comment("Juliana", "Finalmente entendi isso!"));
        videos.Add(video2);

        // Criar e configurar vídeo 3
        Video video3 = new Video("Entity Framework para Iniciantes", "Code Master", 900);
        video3.AddComment(new Comment("Roberto", "Muito claro e objetivo."));
        video3.AddComment(new Comment("Patricia", "Me salvou no projeto da faculdade!"));
        video3.AddComment(new Comment("Marcos", "Obrigado pelas dicas!"));
        videos.Add(video3);

        // Criar e configurar vídeo 4
        Video video4 = new Video("Design Patterns em C#", "Software Architect", 1500);
        video4.AddComment(new Comment("Gabriel", "Ótima didática!"));
        video4.AddComment(new Comment("Larissa", "Finalmente alguém que explica bem!"));
        video4.AddComment(new Comment("Rafael", "Poderia fazer mais exemplos práticos?"));
        video4.AddComment(new Comment("Camila", "Muito completo, parabéns!"));
        videos.Add(video4);

        // Exibir informações dos vídeos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Título: {video.Title}");
            Console.WriteLine($"Autor: {video.Author}");
            Console.WriteLine($"Duração: {video.LengthInSeconds} segundos");
            Console.WriteLine($"Número de Comentários: {video.GetNumberOfComments()}");
            
            Console.WriteLine("\nComentários:");
            foreach (Comment comment in video.GetAllComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            
            Console.WriteLine("\n----------------------------------------\n");
        }
    }
}