﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FlightSimulator.Views
{
    public partial class Joystick :UserControl
    {
        public Joystick()
        {
            InitializeComponent();
            center = new Point(Base.Width / 2 - KnobBase.Width / 2, Base.Height / 2 - KnobBase.Height / 2);
            radius = Base.Width / 2;
            maxDist = Base.Width / 2 - KnobBase.Width / 2;
        }
        private Point mouseDownLoc = new Point();
        private Point center;
        private double radius;
        private double maxDist;
        public static readonly DependencyProperty elevator = DependencyProperty.Register("Elevator", typeof(double), typeof(Joystick), null);
        public static readonly DependencyProperty rudder = DependencyProperty.Register("Rudder", typeof(double), typeof(Joystick), null);


        private void centerKnob_Completed(object sender, EventArgs e) { }


        private void Knob_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            knobPosition.X = 0;
            knobPosition.Y = 0;
            Rudder = knobPosition.X;
            Elevator = knobPosition.Y;

        }

        private void Knob_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - mouseDownLoc.X;
                double y = e.GetPosition(this).Y - mouseDownLoc.Y;
                double dist = Math.Sqrt(x * x + y * y);
                double m;
                
                if (dist <= maxDist)
                {
                  
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    setNormalRudder();
                    setNormalElevator();
                }
                else
                {
                    if (x == 0)
                    {
                        knobPosition.X = 0;
                        Rudder = 0;
                        if (y > 0)
                        {
                            knobPosition.Y = 125;
                        }
                        else
                        {
                            knobPosition.Y = -125;
                        }
                        setNormalElevator();
                    }
                    else
                    {
                        m = y / x;
                        knobPosition.X = maxDist / Math.Sqrt(m * m + 1);
                        setNormalRudder();
                        if (x < 0)
                        {
                            knobPosition.X = -1 * knobPosition.X;
                            setNormalRudder();
                        }
                        knobPosition.Y = m * knobPosition.X;
                        setNormalElevator();
                    }
                    
                }
             
            }
        }

        private void Knob_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                mouseDownLoc = e.GetPosition(this);
                Knob.CaptureMouse();
            }
        }

        public double Rudder
        {
            get
            {
                return Convert.ToDouble(GetValue(rudder));
            }
            set
            {
                SetValue(rudder, value);
            }
        }

        public double Elevator
        {
            get
            {
                return Convert.ToDouble(GetValue(elevator));
            }
            set
            {
                SetValue(elevator, value);
            }
        }

        private void setNormalRudder()
        {
            Rudder = 2 * ((knobPosition.X + maxDist) / (maxDist*2)) - 1;
        }

        private void setNormalElevator()
        {
            Elevator = -1 * (2 * ((knobPosition.Y + maxDist) / (maxDist*2)) - 1);
        }
    }
}
