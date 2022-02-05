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
    internal class GradesBaseClass : Java.Lang.Object
    {
        private Assignment[] assignments;
        private int grade;
        private string name;

        public GradesBaseClass(Assignment[] assignments, int grade, string name)
        {
            this.assignments = assignments;
            this.grade = grade;
            this.name = name;
        }

        public GradesBaseClass(int grade, string name)
        {
            this.assignments = null;
            this.grade = grade;
            this.name = name;
        }

        public GradesBaseClass(string name)
        {
            this.assignments = null;
            this.grade = 0;
            this.name = name;
        }

        public int Grade { get => grade; set => grade = value; }
        public string Name { get => name; set => name = value; }
        internal Assignment[] Assignments { get => assignments; set => assignments = value; }
    }
}