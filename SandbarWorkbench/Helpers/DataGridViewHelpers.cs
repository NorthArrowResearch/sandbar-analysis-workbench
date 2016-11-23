using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Helpers
{
    public class DataGridViewHelpers
    {
        public static void ConfigureDataGridView(ref DataGridView dg, DockStyle eDock, bool bMultiSelect, bool bAutoGenerateCols)
        {
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.ReadOnly = true;
            dg.AllowUserToResizeRows = false;
            dg.RowHeadersVisible = false;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.MultiSelect = bMultiSelect;
            dg.Dock = eDock;
            dg.AutoGenerateColumns = bAutoGenerateCols;
        }
        public static void AddDataGridViewTextColumn(ref DataGridView dg, string sHeaderText, string sDataPropertyMember, bool bVisible, string sFormat = "", DataGridViewAutoSizeColumnMode eAutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, DataGridViewContentAlignment eAlignment = DataGridViewContentAlignment.MiddleLeft)
        {
            var aCol = new DataGridViewTextBoxColumn();
            aCol.Visible = bVisible;
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = sDataPropertyMember;
            aCol.AutoSizeMode = eAutoSizeMode;
            aCol.DefaultCellStyle.Alignment = eAlignment;

            if (!string.IsNullOrEmpty(sFormat))
                aCol.DefaultCellStyle.Format = sFormat;

            dg.Columns.Add(aCol);
        }

        public static void AddDataGridViewCheckboxColumn(ref DataGridView dg, string sHeaderText)
        {
            var aCol = new DataGridViewCheckBoxColumn();
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = "Visible";
            aCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            aCol.FalseValue = false;
            aCol.TrueValue = true;
            dg.Columns.Add(aCol);
        }

        public static void AddDataGridViewLinkColumn(ref DataGridView dg, string sHeaderText, string sDataPropertyMember, bool bVisible, DataGridViewContentAlignment eAlignment = DataGridViewContentAlignment.MiddleLeft)
        {
            var aCol = new DataGridViewLinkColumn();
            aCol.Visible = bVisible;
            aCol.HeaderText = sHeaderText;
            aCol.DataPropertyName = sDataPropertyMember;
            aCol.UseColumnTextForLinkValue = false;
            aCol.DefaultCellStyle.Alignment = eAlignment;
            aCol.Name = sHeaderText.Replace(" ", "");
            dg.Columns.Add(aCol);
        }

        public static void AddDataGridViewAuditColumns(ref DataGridView dg)
        {
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref dg, "Added On", "Audit_AddedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref dg, "Added By", "Audit_AddedBy", true);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref dg, "Updated On", "Audit_UpdatedOn", true, SandbarWorkbench.Properties.Resources.DataGridViewDateFormat);
            Helpers.DataGridViewHelpers.AddDataGridViewTextColumn(ref dg, "Updated By", "Audit_UpdatedBy", true);
        }
    }

    #region Child Property Helpers

    /// <summary>
    /// The code in this block was obtained from StackExchange. It helps DataGridViews
    /// bind to the properties of member objects when using BindingLists. See SandbarSurvey
    /// for how to use this. It allows the datagridview to display the properties of the AuditTrail
    /// member variable.
    /// http://stackoverflow.com/questions/14259080/child-level-object-property-binding-in-datagridview-controls-in-c-sharp-winfor
    /// </summary>
    public class MyCustomTypeDescriptor : CustomTypeDescriptor
    {
        Type typeProperty;
        public MyCustomTypeDescriptor(ICustomTypeDescriptor parent, Type type)
            : base(parent)
        {
            typeProperty = type;
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection cols = base.GetProperties(attributes);

            string propertyName = "";
            foreach (PropertyDescriptor col in cols)
            {
                if (col.PropertyType.Name == typeProperty.Name)
                    propertyName = col.Name;
            }
            PropertyDescriptor pd = cols[propertyName];
            PropertyDescriptorCollection children = pd.GetChildProperties();
            PropertyDescriptor[] array = new PropertyDescriptor[cols.Count + children.Count];
            int count = cols.Count;
            cols.CopyTo(array, 0);

            foreach (PropertyDescriptor cpd in children)
            {
                array[count] = new SubPropertyDescriptor(pd, cpd, pd.Name + "_" + cpd.Name);
                count++;
            }

            PropertyDescriptorCollection newcols = new PropertyDescriptorCollection(array);
            return newcols;
        }

    }

    public class SubPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor _subPD;
        private PropertyDescriptor _parentPD;

        public SubPropertyDescriptor(PropertyDescriptor parentPD, PropertyDescriptor subPD, string pdname)
            : base(pdname, null)
        {
            _subPD = subPD;
            _parentPD = parentPD;
        }

        public override bool IsReadOnly { get { return false; } }
        public override void ResetValue(object component) { }
        public override bool CanResetValue(object component) { return false; }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return _parentPD.ComponentType; }
        }
        public override Type PropertyType { get { return _subPD.PropertyType; } }

        public override object GetValue(object component)
        {
            return _subPD.GetValue(_parentPD.GetValue(component));
        }

        public override void SetValue(object component, object value)
        {
            _subPD.SetValue(_parentPD.GetValue(component), value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }

    #endregion
}
