namespace CubeDomain
{
    public interface ICoordinates
    {
        public string Id { get; set; } 
        public int X { get; set; }
        public int W { get; set; }
        public ITheShapes<ICoordinates> Shape { get; set; }
        public string ShapeId { get; set; }
        
    }
}
