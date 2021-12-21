namespace CubeDomain
{
    public interface IOperations<Tcoordinate, Tshape>
    {
        void UpdateACoordinateValue(Tshape shape, Tcoordinate coordinate);
        int QueryTheShape(Tshape shape, Tcoordinate coordinate1, Tcoordinate coordinate2);
    }
}
