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

namespace Homework_WpfApp17
{
    /// <summary>
    /// Логика взаимодействия для ColorIndicator.xaml
    /// </summary>
    public partial class ColorIndicator : UserControl
    {
        public static readonly DependencyProperty ColorProperty=
            DependencyProperty.Register(
                nameof(Color),
                typeof(Color),
                typeof(ColorIndicator),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(ColorChanged)));

        private static void ColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorIndicator colorindicator = (ColorIndicator)sender;
            colorindicator.Red = newColor.R;
            colorindicator.Green = newColor.G;
            colorindicator.Blue = newColor.B;
        }

        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                nameof(Red),
                typeof(byte),
                typeof(ColorIndicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(ColorRGBChanged)));
        public static readonly DependencyProperty GreenProperty=
            DependencyProperty.Register(
                nameof(Green),
                typeof(byte),
                typeof(ColorIndicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(ColorRGBChanged)));
        public static readonly DependencyProperty BlueProperty=
            DependencyProperty.Register(
                nameof(Blue),
                typeof(byte),
                typeof(ColorIndicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(ColorRGBChanged)));

        private static void ColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorIndicator colorindicator = (ColorIndicator)sender;
            Color color = colorindicator.Color;
            if(e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            if(e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            if(e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }
            colorindicator.Color = color;
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }
        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly RoutedEvent ColorChangedEvent =
           EventManager.RegisterRoutedEvent(
               nameof(ColorChanged),
               RoutingStrategy.Bubble,
               typeof(RoutedPropertyChangedEventHandler<Color>),
               typeof(ColorIndicator));

        public event RoutedPropertyChangedEventHandler<Color> ColorChangedE
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        public ColorIndicator()
        {
            InitializeComponent();
        }
    }
}
