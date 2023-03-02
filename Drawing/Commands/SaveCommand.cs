using System.IO;

namespace Drawing.Commands;

public class SaveCommand : Command
{
    private readonly string _filename;
    
    internal SaveCommand(params object[] commandParameters)
    {
        if (commandParameters.Length > 0)
            _filename = commandParameters[0] as string;
    }

    public override bool Execute()
    {
        StreamWriter writer = new StreamWriter(_filename);
        
        if (Receiver == null) return false;

        Receiver.Save(writer.BaseStream);
        writer.Close();

        return true;
    }
}
