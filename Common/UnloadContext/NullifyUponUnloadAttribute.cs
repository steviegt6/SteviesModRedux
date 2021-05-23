using System;

namespace SteviesModRedux.Common.UnloadContext
{
    /// <summary>
    ///     Attribute that specifies that, once the mod is unloaded, the associated field's value should be set to <c>null</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class NullifyUponUnloadAttribute : SetUponUnloadAttribute
    {
        public NullifyUponUnloadAttribute() : base(null)
        {
        }
    }
}