using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public partial class MethodInvokeForm : Form
    {
        public MethodInvokeForm(MethodInfo method)
        {
            InitializeComponent();

            _method = method;

            InitAssemblyList();

        }

        private MethodInfo _method;
        public MethodInfo Method
        {
            get { return _method; }
        }

        List<Assembly> _loadedAssemblies = new List<Assembly>();
        List<Type> _assemblyTypes = new List<Type>();
        List<MethodInfo> _typeMethods = new List<MethodInfo>();

        private void InitAssemblyList()
        {
            _loadedAssemblies.Clear();
            _loadedAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies());
            _loadedAssemblies.Sort(CompareAssemblies);
            _assemblyComboBox.Items.Clear();
            foreach (Assembly assembly in _loadedAssemblies)
            {
                _assemblyComboBox.Items.Add(assembly.FullName);
            }
        }

        private void _assemblyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _assemblyTypes.Clear();
            _assemblyTypes.AddRange(_loadedAssemblies[_assemblyComboBox.SelectedIndex].GetTypes());
            _assemblyTypes.Sort(CompareTypes);
            _typeComboBox.Items.Clear();
            foreach (Type type in _assemblyTypes)
            {
                _typeComboBox.Items.Add(type.FullName);
            }
        }

        private void _typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _typeMethods.Clear();
            _typeMethods.AddRange(_assemblyTypes[_typeComboBox.SelectedIndex].GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
            _typeMethods.Sort(CompareMethods);
            _methodComboBox.Items.Clear();

            foreach (MethodInfo methodBase in _typeMethods)
            {
                _methodComboBox.Items.Add(methodBase.Name);
            }
        }

        private void _methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _method = _typeMethods[_methodComboBox.SelectedIndex];
        }

        protected static int CompareAssemblies(Assembly x, Assembly y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
        protected static int CompareTypes(Type x, Type y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
        protected static int CompareMethods(MethodInfo x, MethodInfo y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private void MethodInvokeForm_Load(object sender, EventArgs e)
        {
            if (Method != null)
            {
                _assemblyComboBox.SelectedIndex = _loadedAssemblies.IndexOf(Method.DeclaringType.Assembly);
                _typeComboBox.SelectedIndex = _assemblyTypes.IndexOf(Method.DeclaringType);
                _methodComboBox.SelectedIndex = _typeMethods.IndexOf(Method);
            }
        }

    }
}