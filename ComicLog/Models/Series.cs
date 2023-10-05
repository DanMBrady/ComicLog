namespace ComicLog.Models
{
    public class Series
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Comic { get; set; }

        public int UserId { get; set; }

        public bool IsManga { get; set; }

        public bool IsCompleted { get; set; }
    }
}
