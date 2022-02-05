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
using System.Timers;

namespace GradesSystem
{
    [Activity(Label = "AcademyGradesScreen")]
    public class AcademyGradesScreen : Activity
    {
        TextView GPA, academic_credit;
        Button AddSemester, refresh;

        AcademyGradesListAdapter Adapter;
        ExpandableListView SemestersListView;
        List<string> Semesters;
        Dictionary<string, List<Course>> Courses;
        int previousGroup = -1, n = 0;

        double AverageWeighted = 0, credit = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AcademyGradesScreen);

            // Create your application here
            GPA = FindViewById<TextView>(Resource.Id.tv_GPA);
            academic_credit = FindViewById<TextView>(Resource.Id.tv_credit);
            SemestersListView = FindViewById<ExpandableListView>(Resource.Id.explv_semesters);
            AddSemester = FindViewById<Button>(Resource.Id.btn_SemesterAdd);
            refresh = FindViewById<Button>(Resource.Id.btn_refresh);

            Semesters = new List<string>();
            Courses = new Dictionary<string, List<Course>>();

            //Bind list
            Adapter = new AcademyGradesListAdapter(this, Semesters, Courses);
            SemestersListView.SetAdapter(Adapter);

            FnClickEvents();

            AddSemester.Click += AddSemester_Click;
            refresh.Click += Refresh_Click;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            AverageWeighted = 0;
            credit = 0;
            foreach (string s in Semesters)
            {
                foreach (Course c in Courses[s])
                {
                    AverageWeighted += c.Credit * c.Grade;
                    credit += c.Credit;
                }
            }
            if (credit != 0) { AverageWeighted /= credit; }
            else { AverageWeighted = 0; }

            GPA.Text = "GPA: " + AverageWeighted;
            academic_credit.Text = "Academic Credit: " + credit;
        }

        private void AddSemester_Click(object sender, EventArgs e)
        {
            Semesters.Add("" + (++n));
            var lst = new List<Course>();
            lst.Add(new Course("new course"));
            Courses.Add(Semesters[(Adapter.GroupCount) - 1], lst);

            Adapter = new AcademyGradesListAdapter(this, Semesters, Courses);
            SemestersListView.SetAdapter(Adapter);
        }

        void FnClickEvents()
        {
            //Listening to child item selection
            SemestersListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) { };

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            SemestersListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e)
            {
                if (e.GroupPosition != previousGroup)
                    SemestersListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };

            //Listening to group collapse
            SemestersListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e) { };
        }

        /*
        void FnGetListData()
        {
            // Adding child data
            Semesters[0] = "Winter 2019/20";
            Semesters[1] = "Spring 2020";
            Semesters[2] = "Summer 2020";

            // Adding child data
            var lst1 = new Course[0];

            var Biology1_Assignments = new Assignment[6];
            Biology1_Assignments[0] = new Assignment(100, 4, "HW1");
            Biology1_Assignments[1] = new Assignment(100, 4, "HW2");
            Biology1_Assignments[2] = new Assignment(100, 4, "HW3");
            Biology1_Assignments[3] = new Assignment(85, 4, "HW4");
            Biology1_Assignments[4] = new Assignment(100, 4, "HW5");
            Biology1_Assignments[5] = new Assignment(90, 80, "Test");
            lst1[0] = new Course(Biology1_Assignments, 91, "Biology 1", 3);

            var lst2 = new Course[0];
            //lst2[0] = new Course(Biology1_Assignments, 91, "Biology 2", 3);

            var lst3 = new Course[0];
            //lst3[0] = new Course(Biology1_Assignments, 91, "Biology 3", 3);


            // Header, Child data
            Courses.Add(Semesters[0], lst1);
            Courses.Add(Semesters[1], lst2);
            Courses.Add(Semesters[2], lst3);
            
        }
    */
    }
}