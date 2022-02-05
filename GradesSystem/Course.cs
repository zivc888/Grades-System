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
    class Course : GradesBaseClass
    {
        double credit;

        public Course(Assignment[] assignments, int grade, string name,double credit):base(assignments, grade, name)
        {
            this.credit = credit;
        }

        public Course(int grade, string name, double credit) : base(grade, name)
        {
            this.credit = credit;
        }

        public Course(string name) : base(name)
        {
            this.credit = 0;
        }

        public double Credit { get => credit; set => credit = value; }
    }
}