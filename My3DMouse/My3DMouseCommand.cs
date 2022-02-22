using Rhino;
using Rhino.Commands;
using Rhino.Input;
using Rhino.Input.Custom;



namespace My3DMouse
{

    [System.Runtime.InteropServices.Guid("31bb38dc-acf8-41e8-884d-81691693edb8")]
    public class My3DMouseCommand : Command
    {
        public My3DMouseCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static My3DMouseCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "My3DMouseCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            var enabled = My3DMouse.Instance.IsEnabled;
            var prompt = enabled ? "Event watcher is enabled. New value" : "Event watcher is disabled. New value";

            var go = new GetOption();
            go.SetCommandPrompt(prompt);
            go.AcceptNothing(true);

            var d_option = go.AddOption("Disable");
            var e_option = go.AddOption("Enable");
            var t_option = go.AddOption("Toggle");

            var res = go.Get();
            if (res == GetResult.Nothing)
                return Result.Success;
            if (res != GetResult.Option)
                return Result.Cancel;

            var option = go.Option();
            if (null == option)
                return Result.Failure;

            if (d_option == option.Index)
            {
                if (enabled)
                    My3DMouse.Instance.Enable(false);
            }
            else if (e_option == option.Index)
            {
                if (!enabled)
                    My3DMouse.Instance.Enable(true);
            }
            else if (t_option == option.Index)
            {
                My3DMouse.Instance.Enable(!enabled);
            }

            return Result.Success;
        }
    }
}
