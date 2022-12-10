namespace AdventOfCode.Day2;

public class Round
{
    private readonly Elf _opponent;
    public Elf Me { get; }

    public Round(Elf opponent, Elf me)
    {
        _opponent = opponent;
        Me = me;
    }

    public void PlayRound()
    {
        if (_opponent.Selection.IsDraw(Me.Selection))
        {
            Draw(_opponent, Me);
            return;
        }

        AppointWinner(_opponent.Selection.Beats(Me.Selection) ? _opponent : Me);
    }

    private static void Draw(params Elf[] elves)
    {
        foreach (var elf in elves)
        {
            elf.AddToScore(3);
        }
    }

    private static void AppointWinner(Elf elf)
    {
        elf.AddToScore(6);
    }
}