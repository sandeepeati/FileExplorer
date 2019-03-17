using FileExplorer.General;
using FileExplorer.Models;
using FileExplorer.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileExplorer.Extended
{
    public class FE_ContentCard_Click
    {
        public static readonly DependencyProperty ClickProperty =
            DependencyProperty.RegisterAttached("Click",
                typeof(ICommand), typeof(FE_ContentCard_Click),
                new UIPropertyMetadata(null, OnClick));

        public static void SetClick(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ClickProperty, value);
        }

        public static ICommand GetClick(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ClickProperty);
        }

        private static void OnClick(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ContentCard element = obj as ContentCard;

            if (element != null)
            {
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    element.MouseLeftButtonDown += new MouseButtonEventHandler(element_mouseDown);
                }
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    element.MouseLeftButtonDown -= new MouseButtonEventHandler(element_mouseDown);
                }
            }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter",
                typeof(object), typeof(FE_ContentCard_Click),
                new PropertyMetadata(-1));

        public static void SetCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(CommandParameterProperty);
        }


        static void element_mouseDown(object sender, MouseEventArgs e)
        {
            ContentCard element = sender as ContentCard;

            FE_Command command = (FE_Command)element.GetValue(ClickProperty);
            FE_DirectoryContents_M contents = (FE_DirectoryContents_M)GetCommandParameter((DependencyObject)sender);
            command.Execute(contents);
        }
    }
}
