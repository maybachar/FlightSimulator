﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;

namespace FlightSimulatorApp
{
    // AirplaneModel Interface.
    public interface IAirplaneModel : INotifyPropertyChanged
    {
        // Connection to the airplane.
        void Connect();
        void Reconnect();
        void Disconnect();
        void Start();
        void AddSetCommand(string varName, double value);

        // Dashboard properties.
        double Heading { set; get; }
        double VerticalSpeed { set; get; }
        double GroundSpeed { set; get; }
        double Airspeed { set; get; }
        double Altitude { set; get; }
        double Roll { set; get; }
        double Pitch { set; get; }
        double Altimeter { set; get; }
        string ErrorScreen { set; get; }

        // Map properties.
        double Longitude { set; get; }
        double Latitude { set; get; }
        Location Location { set; get; }

        // Controls properties.
        double Rudder { set; get; }
        double Elevator { set; get; }
        double Throttle { set; get; }
        double Aileron { set; get; }

        // Settings properties.
        string Ip { set; get; }
        string Port { set; get; }
        string ConnectionErrorMessage { set; get; }
    }
}
