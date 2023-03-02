using System.IO;

namespace Drawing.Commands;

public class LoadCommand : Command
{
    private readonly string _filename;

    internal LoadCommand(params object[] commandParameters)
    {
        if (commandParameters.Length > 0)
            _filename = commandParameters[0] as string;
    }

    public override bool Execute()
    {
        StreamReader reader = new StreamReader(_filename);

        if (Receiver == null) return false;

        Receiver.Load(reader.BaseStream);
        reader.Close();

        return true;
    }
}
