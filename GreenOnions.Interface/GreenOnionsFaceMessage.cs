namespace GreenOnions.Interface
{
    public record GreenOnionsFaceMessage : GreenOnionsBaseMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GreenOnionsFaceMessage(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
