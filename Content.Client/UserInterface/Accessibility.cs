using System.Numerics;


namespace Content.Client;


public record Line(string Text, float Time);


public interface IStimulus
{
}

public record Stimulus(string Actor = "", string Description = "", string Text = "", Vector2? RelativePosition = null, string Channel = "", float Volume = 0f, float Pitch = 0f, float Speed = 1f) : IStimulus;


public record SoundModifiers();



public interface IAction { }

public class SayAction : IAction
{
    public string Text;
    public float Speed;

    public SayAction(string text, float speed = 1.0f)
    {
        Text = text;
        Speed = speed;
    }
}

public class EmoteAction : IAction
{
    public string Description;

    public EmoteAction(string description)
    {
        Description = description;
    }
}


/// the perception of a player
public interface IPlayer
{
    void Sense(IStimulus stimulus);

    IAction[] GetActions();
}


sealed class FilePlayer : IPlayer
{
    readonly private string _sense_filename = "sense.jsonl";

    public void Sense(IStimulus stimulus)
    {
        // var jsonString = JsonSerializer.Serialize(stimulus);

        // lock (_sense_filename)
        // {
        // File.AppendAllText(_sense_filename, jsonString + "\n");
        var message = stimulus.ToString();
        Logger.InfoS("accessibility", message ?? "null");
        // }

    }

    public IAction[] GetActions()
    {
        return Array.Empty<IAction>();
    }

}

public static class Accessibility
{
    private static readonly IPlayer Player = new FilePlayer();

    public static void Sense(IStimulus stimulus)
    {
        Player.Sense(stimulus);
    }

}

