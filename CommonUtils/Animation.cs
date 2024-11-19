namespace CommonUtils;

public abstract class Animation(string[] frames, int interval) {

    protected string[] frames = frames;
    private readonly int interval = interval;

    public void Play(int maxLoops) {
        int runs = 0;
        while (runs < maxLoops) {
            foreach (string frame in frames) {
                Console.Write(frame);
                Thread.Sleep(interval);
                string backspaces = new('\b', frame.Length);
                Console.Write($"{backspaces}{new string(' ', frame.Length)}{backspaces}");
            }
            runs++;
        }
    }

    public void Play() {
        Play(1);
    }
}