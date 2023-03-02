namespace Drawing.Commands;

public class DeselectAllCommand : Command
{
    internal DeselectAllCommand() { }

    public override bool Execute()
    {
        if (Receiver == null) return false;
        
        Receiver.DeselectAll();

        return true;
    }
}
