﻿using FlightSimulatorApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IAirplaneModel airplaneModel;
        public SettingsViewModel settingsVM;
        public DashboardViewModel dashboardVM;
        public MapViewModel mapVM;
        public ControlsViewModel controlsVM;

        void App_Startup(object sender, StartupEventArgs e)
        {

            airplaneModel = new MyAirplaneModel();
            settingsVM = new SettingsViewModel(airplaneModel);
            //ViewModel viewModel = new ViewModel(airplaneModel);
            dashboardVM = new DashboardViewModel(airplaneModel);
            mapVM = new MapViewModel(airplaneModel);
            controlsVM = new ControlsViewModel(airplaneModel);
        }
    }
}
