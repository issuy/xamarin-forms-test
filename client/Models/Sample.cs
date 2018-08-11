namespace client.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public string Due { get; set; }
    }
}
