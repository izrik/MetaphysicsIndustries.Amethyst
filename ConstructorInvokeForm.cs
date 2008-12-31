using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class ConstructorInvokeForm : Form
    {
        public ConstructorInvokeForm(ConstructorInfo constructor)
        {
            InitializeComponent();

            _constructor = constructor;

            InitAssemblyList();
        }


        private ConstructorInfo _constructor;
        public ConstructorInfo Constructor
        {
            get { return _constructor; }
        }

        List<Assembly> _loadedAssemblies = new List<Assembly>();
        List<Type> _assemblyTypes = new List<Type>();
        List<ConstructorInfo> _typeConstructors = new List<ConstructorInfo>();

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
            _typeConstructors.Clear();
            _typeConstructors.AddRange(_assemblyTypes[_typeComboBox.SelectedIndex].GetConstructors(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
            _typeConstructors.Sort(CompareConstructors);
            _constructorComboBox.Items.Clear();

            foreach (ConstructorInfo constructor in _typeConstructors)
            {
                _constructorComboBox.Items.Add(constructor.Name);
            }
        }

        private void _constructorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _constructor = _typeConstructors[_constructorComboBox.SelectedIndex];
        }

        protected static int CompareAssemblies(Assembly x, Assembly y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
        protected static int CompareTypes(Type x, Type y)
        {
            return x.FullName.CompareTo(y.FullName);
        }
        protected static int CompareConstructors(ConstructorInfo x, ConstructorInfo y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private void ConstructorInvokeForm_Load(object sender, EventArgs e)
        {
            if (Constructor != null)
            {
                _assemblyComboBox.SelectedIndex = _loadedAssemblies.IndexOf(Constructor.DeclaringType.Assembly);
                _typeComboBox.SelectedIndex = _assemblyTypes.IndexOf(Constructor.DeclaringType);
                _constructorComboBox.SelectedIndex = _typeConstructors.IndexOf(Constructor);
            }
        }

        private static string ComposeConstructorString(ConstructorInfo constructorBase)
        {
            return string.Join(", ", Array.ConvertAll<ParameterInfo, string>(constructorBase.GetParameters(), GetParameterName));
        }
        private static string GetParameterName(ParameterInfo pi)
        {
            return pi.Name;
        }
    }
}