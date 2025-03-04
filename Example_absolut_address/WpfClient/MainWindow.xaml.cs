﻿using Microsoft.ServiceFabric.Services.Communication.Wcf;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ConnectToWcfService();
            InitializeComponent();
        }

        public void ConnectToWcfService()
        {
            // var ret = HelloProxy.Instance.Hello();
            string uri = "net.tcp://localhost:1000/Gateway/WcfService";
            var ret = WcfClientProxy<IHelloContract>.InvokeMethod<string>(x => x.Hello(), WcfUtility.CreateTcpClientBinding(), new System.ServiceModel.EndpointAddress(uri));
        }
    }
}