namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            int input = int.Parse(Console.ReadLine());

            string exportAlbumsInfo = ExportAlbumsInfo(context, input);
            string exportSongsAboveDuration = ExportSongsAboveDuration(context, input);

            //Console.WriteLine(exportAvlumsInfo);
            Console.WriteLine(exportSongsAboveDuration);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x => x.Price)
                .ToList();

            var producers = context.Producers
                .Where(x => x.Id == producerId)
                .ToList();

            string producerName = string.Empty;

            foreach (var producer in producers)
            {
                producerName = producer.Name;
            }

            int songCounter = 1;

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                    .AppendLine($"-ProducerName: {producerName}")
                    .AppendLine($"-Songs:");

                var songs = album.Songs
                    .OrderByDescending(x => x.Name)
                    .ThenBy(x => x.Writer);

                foreach (var song in songs)
                {
                    sb.AppendLine($"---#{songCounter}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.Writer.Name}");

                    songCounter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    Writer = s.Writer.Name,
                    PerformerFullName = s.SongPerformers
                        .ToList()
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.PerformerFullName)
                .ToList();

            int songCounter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{songCounter++}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
