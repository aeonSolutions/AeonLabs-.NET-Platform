using System;
using System.ComponentModel;

namespace BlueActivity
{
    public class ColorWithAlphaTypeConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (ReferenceEquals(destType, typeof(string)))
            {
                return true;
            }

            return base.CanConvertTo(context, destType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (ReferenceEquals(destType, typeof(string)))
            {
                return "My color";
            }

            return base.ConvertTo(context, culture, value, destType);
        }
    }
}