public class DI
{
    public static readonly DI di = new DI();

    public InputManager inputManager { get; private set; }
    public ProgressSaver progressSaver { get; } = new ProgressSaver();
    public GameManager gameManager { get; private set; }
    public SoundManager soundManager { get; private set; }

    public void SetGameManager(GameManager gameManager) => this.gameManager = gameManager;
    public void SetInputManager(InputManager inputManager) => this.inputManager = inputManager;
    public void SetSoundManager(SoundManager soundManager) => this.soundManager = soundManager;

    private DI() { }
}
