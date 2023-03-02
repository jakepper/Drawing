namespace Drawing.Commands;

public class RemoveSelectedCommand : Command
{
    public override bool Execute()
    {
        if (Receiver == null) return false;

        Receiver.DeleteAllSelected();

        return true;
    }
}
