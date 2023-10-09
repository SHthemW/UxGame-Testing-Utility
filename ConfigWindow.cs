using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        public ConfigData Config => new(_dataSrcPathBox.Text, _deployProgPathBox.Text);

    }
}
