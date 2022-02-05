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
    [Activity(Label = "MainGradesScreen")]
    public class MainGradesScreen : Activity
    {
        private Button school, academy;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainGradesScreen);

            // Create your application here
            school = FindViewById<Button>(Resource.Id.btn_school);
            school.Click += School_Click;

            academy = FindViewById<Button>(Resource.Id.btn_academy);
            academy.Click += Academy_Click;
        }

        private void Academy_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(AcademyGradesScreen));
            StartActivity(i);
        }

        private void School_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}