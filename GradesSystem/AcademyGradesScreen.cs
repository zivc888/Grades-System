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
        Android.App.Dialog DefineSemesterDialog;

        AcademyGradesListAdapter Adapter;
        ExpandableListView SemestersListView;
        List<string> Semesters;
        Dictionary<string, List<Course>> Courses;
        int previousGroup = -1;

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

            GPA.Text = "GPA: " + Math.Round(AverageWeighted,2);
            academic_credit.Text = "Academic Credit: " + credit;
        }

        private void AddSemester_Click(object sender, EventArgs e)
        {
            var lst = new List<Course>();

            DefineSemesterDialog = new Android.App.Dialog(this);
            DefineSemesterDialog.SetContentView(Resource.Layout.SemesterCourseNumberDialog);
            DefineSemesterDialog.SetTitle("Define Semester");
            DefineSemesterDialog.SetCancelable(true);
            EditText name = DefineSemesterDialog.FindViewById<EditText>(Resource.Id.et_name);
            EditText num = DefineSemesterDialog.FindViewById<EditText>(Resource.Id.et_course_num);
            Button save = DefineSemesterDialog.FindViewById<Button>(Resource.Id.btn_SaveCourse);

            save.Click += (object sender, EventArgs e) =>
            {

                if (name.Text == "" || num.Text == "") { Toast.MakeText(this, "error", ToastLength.Short).Show(); }
                else
                {
                    Toast.MakeText(this, "saved", ToastLength.Short).Show();
                    Semesters.Add("" + name.Text);

                    for (int i = 0; i < int.Parse(num.Text); i++)
                    {
                        lst.Add(new Course("course " + (i+1)));
                    }
                    Courses.Add(Semesters[(Adapter.GroupCount) - 1], lst);
                }
            };
            DefineSemesterDialog.Show();


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
    }
}