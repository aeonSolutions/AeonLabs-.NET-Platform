using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace BlueActivity
{
    internal class ColorWithAlphaCollectionEditor : CollectionEditor
    {
        private CollectionForm cfForm;

        public ColorWithAlphaCollectionEditor(Type Type) : base(Type)
        {
        }

        protected override CollectionForm CreateCollectionForm()
        {
            cfForm = base.CreateCollectionForm();
            return cfForm;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (cfForm is object && cfForm.Visible)
            {
                return new ColorWithAlphaCollectionEditor(CollectionType);
            }
            else
            {
                return base.EditValue(context, provider, value);
            }
        }
    }
}