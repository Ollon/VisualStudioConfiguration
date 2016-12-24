using System;

namespace Ollon.VisualStudio.Interop
{
    /// <summary>
    /// Represents the various states of an instnce
    /// </summary>
    [Flags]
    public enum InstanceState : uint
    {
        /// <summary>
        /// The instance has no state
        /// </summary>
        None = 0,

        /// <summary>
        /// The instance is local
        /// </summary>
        Local = 1,

        /// <summary>
        /// The instance is registered
        /// </summary>
        Registered = 2,

        /// <summary>
        /// No reboot is required
        /// </summary>
        NoRebootRequired = 4,

        /// <summary>
        /// The instance has completed successfully.
        /// </summary>
        Complete = 4294967295
    }
}