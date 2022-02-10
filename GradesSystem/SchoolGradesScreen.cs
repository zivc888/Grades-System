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
    [Activity(Label = "SchoolGradesScreen")]
    public class SchoolGradesScreen : Activity
    {
        Button bagruts, ongoing;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SchoolGradesScreen);

            // Create your application here
            bagruts = FindViewById<Button>(Resource.Id.btn_bagruts);
            ongoing = FindViewById<Button>(Resource.Id.btn_ongoing);

            bagruts.Click += Bagruts_Click;
            ongoing.Click += Ongoing_Click;
        }

        private void Ongoing_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Bagruts_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}