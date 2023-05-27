using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;


namespace task6
{
    public partial class Form1 : Form
    {
        private List<Type> classes = new List<Type>();

        private List<string> methods = new List<string>();

        Type currType;

        object instance;

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateComboBox1()
        {
            this.comboBox1.Items.Clear();

            foreach (Type t in classes)
            {
                this.comboBox1.Items.Add(t.Name);
            }
        }

        private void UpdateComboBox2()
        {
            this.comboBox2.Items.Clear();

            foreach (string t in methods)
            {
                this.comboBox2.Items.Add(t);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Assembly assembly = Assembly.LoadFrom(openFileDialog.SafeFileName);
                var types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (!type.IsInterface && !type.IsAbstract)
                    {
                        classes.Add(type);
                    }
                }
            }

            UpdateComboBox1();

            this.comboBox1.Visible = true;
            this.classButton.Visible = true;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            var val = this.comboBox1.Text;

            if (val != "")
            {
                var type = classes.Find((t) => t.Name == val);

                currType = type;

                this.methods.Clear();

                foreach (var method in type.GetMethods())
                {
                    this.methods.Add(method.Name);
                }

                this.instance = Activator.CreateInstance(this.currType);

                this.comboBox2.Items.Clear();
                this.comboBox2.Visible = true;
                this.methodButton.Visible = true;

                UpdateComboBox2();
            }
            else
            {
                MessageBox.Show("Класс не выбран!");
            }
        }

        private void methodButton_Click(object sender, EventArgs e)
        {
           
            string methodName = this.comboBox2.Text;

            if (methodName != "")
            {
                var methodInfo = currType.GetMethod(methodName);

                if (methodInfo == null)
                {
                    Console.WriteLine($"Метод {methodName} не найден.");
                    return;
                }

                creareForm(methodInfo, methodName);
            }
            else
            {
                MessageBox.Show("Метод не выбран!");
            }
            
        }

        private void creareForm(MethodInfo methodInfo, string methodName)
        {
            var form = new Form();
            form.Text = methodName;

            var parameters = methodInfo.GetParameters();
            var y = 10;
            foreach (var parameter in parameters)
            {
                var label = new Label();
                label.Text = parameter.Name + ":";
                label.Left = 10;
                label.Top = y;
                form.Controls.Add(label);

                var textBox = new TextBox();
                textBox.Left = 150;
                textBox.Top = y;
                form.Controls.Add(textBox);

                y += 30;
            }

           
            var button = new Button();
            button.Text = "Выполнить";
            button.Left = 100;
            button.Top = y;
            button.Click += (sender, e) =>
            {
                var args = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = Convert.ChangeType(form.Controls[i * 2 + 1].Text, parameters[i].ParameterType);
                }

                try
                {
                    object curInstance = null;

                    if (!methodInfo.IsStatic) 
                    {
                        curInstance = this.instance;
                    }

                    if (methodInfo.ReturnType.ToString() == "System.Void")
                    {
                        methodInfo.Invoke(curInstance, args);
                        MessageBox.Show("Выполнено!");
                    }
                    else
                    {
                        var vap = methodInfo.Invoke(curInstance, args);
                        if (vap != null)
                        {
                            MessageBox.Show(vap.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Поле ещё не создано!");
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("ОШИБКА!");
                }
            };

            form.Controls.Add(button);

            form.ShowDialog();
        }
    }
}
 