using System;
using System.ComponentModel;

namespace BlueActivity
{
    public class ColorWithAlphaCollectionPropertyDescriptor : PropertyDescriptor
    {
        private ColorWithAlphaCollection _Collection = null;
        private int _Index = -1;

        public ColorWithAlphaCollectionPropertyDescriptor(ColorWithAlphaCollection Collection, int Index) : base("#" + Index.ToString(), null)
        {
            _Collection = Collection;
            _Index = Index;
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get
            {
                return _Collection.GetType();
            }
        }

        public override object GetValue(object component)
        {
            return _Collection[_Index];
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return _Collection[_Index].GetType();
            }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }

        public override string DisplayName
        {
            get
            {
                var item = _Collection[_Index];
                return "Color " + _Index;
            }
        }

        public override string Description
        {
            get
            {
                return "Defines a color with an alpha level (0-255). 0 being transparent and 255 being full opaque";
            }
        }

        public override string Name
        {
            get
            {
                return "#" + _Index.ToString();
            }
        }
    }
}