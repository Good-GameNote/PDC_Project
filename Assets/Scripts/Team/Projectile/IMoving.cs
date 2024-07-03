public interface IMoving
{
    public void Moving();
}

public interface IHold : IMoving
{
}

public interface ITargeting : IMoving
{
}

public interface IStraight : IMoving
{
}
