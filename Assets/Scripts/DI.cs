
public class DI
{
    public static readonly DI di = new DI();

    public InputManager inputManager { get; } = new InputManager();

    private DI() { }
}
