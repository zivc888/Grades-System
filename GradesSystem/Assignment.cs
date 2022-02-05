using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradesSystem
{
    internal class Assignment
    {
        private int grade;
        private int percentage;
        private string name;

        public Assignment(int grade, int percentage, string name)
        {
            this.grade = grade;
            this.percentage = percentage;
            this.name = name;
        }

        public int Grade { get => grade; set => grade = value; }
        public int Percentage { get => percentage; set => percentage = value; }
        public string Name { get => name; set => name = value; }
    }
}