using Foolproof;
using System;

namespace IngolStadtNatur.Utilities.Filters
{
    public class RequiredToBeTrueAttribute : ModelAwareValidationAttribute
    {
        //this is needed to register this attribute with foolproof's validator adapter
        static RequiredToBeTrueAttribute() { Register.Attribute(typeof(RequiredToBeTrueAttribute)); }

        public override bool IsValid(object value, object container)
        {
            if (value == null) return false;
            if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");
            return (bool)value;
        }
    }
}