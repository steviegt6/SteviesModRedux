using System;

namespace SteviesModRedux.Common.Utilities.UnloadContext
{
    /// <summary>
    ///     Indicates what value a field shit be set to once the mod unloads. <br />
    ///     Useful for setting fields to null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SetUponUnloadAttribute : Attribute
    {
        public virtual object Value { get; }

        public SetUponUnloadAttribute(object value)
        {
            Value = value;
        }
    }
}