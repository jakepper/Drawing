using Drawing.Components;

namespace Drawing.Commands;

public static class CommandFactory
{
    public enum CommandType { NEW, ADD, REMOVE, SELECT, DESELECT, LOAD, SAVE, NONE }
    public static Canvas Receiver { get; set; }

    /// <summary>
    /// Create -- a factory method for standard commands 
    /// 
    /// This method can be overridden to generate different or custom commands.
    /// </summary>
    /// <param name="commandType"> Type of Command to Create:
    ///             New
    ///             Add
    ///             Remove
    ///             Select
    ///             Deselect
    ///             Load
    ///             Save
    /// </param>
    /// <param name="commandParameters">An array of optional parametesr whose sementics depedent on the command type
    ///     For new, no additional parameters needed
    ///     For add, 
    ///         [0]: Type       reference type for assembly containing the tree type resource
    ///         [1]: string     tree type -- a fully qualified resource name
    ///         [2]: Point      center location for the tree, defaut = top left corner
    ///         [3]: float      scale factor</param>
    ///     For remove, no additional parameters needed
    ///     For select,
    ///         [0]: Point      Location at which a tree could be selected
    ///     For deselect, no additional parameters needed
    ///     For load,
    ///         [0]: string     filename of file to load from  
    ///     For save,
    ///         [0]: string     filename of file to save to  
    /// </param>
    public static Command Create(CommandType commandType, params object[] commandParameters)
    {
        if (commandType == CommandType.NONE) return null;

        if (Receiver == null) return null;

        Command command = null;
        switch (commandType)
        {
            case CommandType.NEW:
                command = new NewCommand();
                break;
            case CommandType.ADD:
                command = new AddCommand(commandParameters);
                break;
            case CommandType.REMOVE:
                command = new RemoveSelectedCommand();
                break;
            case CommandType.SELECT:
                command = new SelectCommand(commandParameters);
                break;
            case CommandType.DESELECT:
                command = new DeselectAllCommand();
                break;
            case CommandType.LOAD:
                command = new LoadCommand(commandParameters);
                break;
            case CommandType.SAVE:
                command = new SaveCommand(commandParameters);
                break;
        }

        if (command != null) command.Receiver = Receiver;

        return command;
    }
}