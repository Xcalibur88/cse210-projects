namespace Develop04.Animations;
using CommonUtils;

public class CountdownAnimation : Animation {
    public CountdownAnimation(int start) : base(new string[start], 1000) {
        for (int i = 0; i < start; i++) {
            frames[i] = $"{start - i}";
        }
    }
}