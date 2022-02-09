using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradesSystem
{
    internal class AcademyGradesListAdapter : BaseExpandableListAdapter
    {

        Activity context;
        private List<string> Semesters;
        private Dictionary<string, List<Course>> Courses;

        Android.App.Dialog EditCourseDialog;


        public AcademyGradesListAdapter(Activity context, List<string> semesters, Dictionary<string, List<Course>> courses)
        {
            this.context = context;
            Semesters = semesters;
            Courses = courses;
        }

        //for child item view
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return Courses[Semesters[groupPosition]][childPosition];
        }
        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            Course child = (Course)GetChild(groupPosition, childPosition);

            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.AcademyGradesListItem, null);
            }

            TextView name = (TextView)convertView.FindViewById(Resource.Id.tv_CourseName);
            name.Text = child.Name + "";
            TextView grade = (TextView)convertView.FindViewById(Resource.Id.tv_CourseGrade);
            grade.Text = child.Grade + "";
            TextView credit = (TextView)convertView.FindViewById(Resource.Id.tv_CourseCredit);
            credit.Text = child.Credit + "";

            Button edit = (Button)convertView.FindViewById(Resource.Id.btn_CourseEdit);
            edit.Click += (object sender, EventArgs e) =>
            {
                EditCourseDialog = new Android.App.Dialog(context);
                EditCourseDialog.SetContentView(Resource.Layout.EditCourseDialog);
                EditCourseDialog.SetTitle("Edit Course");
                EditCourseDialog.SetCancelable(true);
                EditText newname = EditCourseDialog.FindViewById<EditText>(Resource.Id.et_name);
                EditText newgrade = EditCourseDialog.FindViewById<EditText>(Resource.Id.et_grade);
                EditText newcredit = EditCourseDialog.FindViewById<EditText>(Resource.Id.et_credit);
                Button save = EditCourseDialog.FindViewById<Button>(Resource.Id.btn_SaveCourse);

                save.Click += (object sender, EventArgs e) =>
                {
                    
                    if(newname.Text == "" || newgrade.Text == "" || newcredit.Text == "") { Toast.MakeText(context, "error", ToastLength.Short).Show(); }
                    else
                    {
                        Toast.MakeText(context, "saved", ToastLength.Short).Show();
                        child.Name = newname.Text;
                        child.Grade = int.Parse(newgrade.Text);
                        child.Credit = double.Parse(newcredit.Text);
                    }
                    NotifyDataSetChanged();
                };
                EditCourseDialog.Show();
            };

            return convertView;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return Courses[Semesters[groupPosition]].Count;
        }

        //For header view
        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return Semesters[groupPosition];
        }
        public override int GroupCount
        {
            get
            {
                return Semesters.Count;
            }
        }
        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string headerTitle = (string)GetGroup(groupPosition);

            convertView = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.AcademyGradesListHeader, null);
            var name = (TextView)convertView.FindViewById(Resource.Id.tv_SemesterName);
            name.Text = "Semester " + headerTitle;

            return convertView;
        }
        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }
        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

    }

    internal class AcademyGradesListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}