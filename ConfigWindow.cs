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
using UxGame_Testing_Utility.Services;

namespace UxGame_Testing_Utility
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();
            
            if (LocalService.TryLoadConfigDataFromLocal(out var config, out var err)) 
                this.Config = config;
        }

        public ConfigData Config
        {
            get => new(_dataSrcPathBox.Text, _deployProgPathBox.Text);
            private set
            {
                _dataSrcPathBox.Text = value.DataSrcPath;
                _deployProgPathBox.Text = value.DplProgPath;
            }
        }
    }
}
