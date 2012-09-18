using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;

namespace PointLightDemo
{
    static class Extensions
    {
        public static void AddAnimation(this Storyboard storyboard, Timeline timeline, DependencyObject target, DependencyProperty property)
        {
            Storyboard.SetTarget(timeline, target);
            Storyboard.SetTargetProperty(timeline, new PropertyPath(property));
            storyboard.Children.Add(timeline);
        }

        public static void AddAnimation(this Storyboard storyboard, Timeline timeline, string targetName, DependencyProperty property)
        {
            Storyboard.SetTargetName(timeline, targetName);
            Storyboard.SetTargetProperty(timeline, new PropertyPath(property));
            storyboard.Children.Add(timeline);
        }
    }
}
