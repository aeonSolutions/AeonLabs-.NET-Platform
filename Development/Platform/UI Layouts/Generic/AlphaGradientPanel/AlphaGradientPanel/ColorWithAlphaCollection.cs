using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace BlueActivity
{
    [TypeConverter(typeof(ColorWithAlphaCollectionConverter))]
    [Editor(typeof(ColorWithAlphaCollectionEditor), typeof(UITypeEditor))]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    [Serializable()]
    public class ColorWithAlphaCollection : CollectionBase, ICustomTypeDescriptor
    {
        private Control ctlParent;

        public ColorWithAlphaCollection()
        {
        }

        public ColorWithAlphaCollection(Control ParentControl)
        {
            Parent = ParentControl;
        }

        [Browsable(false)]
        public Control Parent
        {
            get
            {
                return ctlParent;
            }

            set
            {
                ctlParent = value;
            }
        }

        protected override void OnSet(int index, object oldValue, object newValue)
        {
            ((ColorWithAlpha)newValue).Parent = Parent;
            base.OnSet(index, oldValue, newValue);
        }

        protected override void OnInsert(int index, object value)
        {
            ((ColorWithAlpha)value).Parent = Parent;
            base.OnInsert(index, value);
        }

        public ColorWithAlpha this[int Index]
        {
            get
            {
                return (ColorWithAlpha)List[Index];
            }
        }

        public ColorWithAlpha Add(ColorWithAlpha value)
        {
            List.Add(value);
            return value;
        }

        public bool Contains(ColorWithAlpha value)
        {
            return List.Contains(value);
        }

        public void Remove(ColorWithAlpha value)
        {
            List.Remove(value);
        }

        public int IndexOf(ColorWithAlpha value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, ColorWithAlpha value)
        {
            List.Insert(index, value);
        }

        public new void Clear()
        {
            base.Clear();
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return null;
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var pdcProperties = new PropertyDescriptorCollection(null);
            for (int i = 0, loopTo = List.Count - 1; i <= loopTo; i++)
            {
                var pdProperty = new ColorWithAlphaCollectionPropertyDescriptor(this, i);
                pdcProperties.Add(pdProperty);
            }

            return pdcProperties;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}