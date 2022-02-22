using System;
using System.IO.Ports;
using Rhino;
using Rhino.Commands;
using Rhino.PlugIns;

namespace My3DMouse
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class My3DMousePlugIn : Rhino.PlugIns.PlugIn

    {
        public My3DMousePlugIn()
        {
            Instance = this;
        }

        ///<summary>Gets the only instance of the My3DMousePlugIn plug-in.</summary>
        public static My3DMousePlugIn Instance
        {
            get; private set;
        }

        public override PlugInLoadTime LoadTime => PlugInLoadTime.AtStartup;

        /// <summary>
        /// Called by Rhino when loading this plug-in.
        /// </summary>
        protected override LoadReturnCode OnLoad(ref string errorMessage)
        {
            RhinoApp.Initialized += RhinoApp_Initialized;
            //My3DMouse.Instance.Enable(true);
            return LoadReturnCode.Success;

        }

        private void RhinoApp_Initialized(object sender, EventArgs e)
        {
            My3DMouse.Instance.Enable(true);
        
        }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.
    }
}