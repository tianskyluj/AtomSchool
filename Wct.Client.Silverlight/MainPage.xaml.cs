using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Wct.Client.Silverlight
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
			Btn1.Click += new RoutedEventHandler(Btn1_Click);
            Btn2.Click += new RoutedEventHandler(Btn2_Click);
            Btn3.Click += new RoutedEventHandler(Btn3_Click);

        }

        void Btn1_Click(object sender, EventArgs e)
        {
            Canvas.SetZIndex(canvas2, 1);
			
            
        }

        void Btn2_Click(object sender, EventArgs e)
        {
            Canvas.SetZIndex(canvas3, 1);
		
            
        }

        void Btn3_Click(object sender, EventArgs e)
        {
            Canvas.SetZIndex(canvas, 1);
		
        }
	}
}